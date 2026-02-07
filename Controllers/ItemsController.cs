using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.Models.DTOs;
using ShoppingBuddy.Services;

namespace ShoppingBuddy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController(IItemService itemService) : ControllerBase
{
    private readonly IItemService _itemService = itemService;

    [HttpPost]
    public async Task<ActionResult<ItemResponseDto>> CreateItem([FromBody] CreateItemDto createItemDto)
    {
        var response = await _itemService.CreateItemAsync(createItemDto);
        return CreatedAtAction(
            nameof(GetItem),           
            new { id = response.Id },         
            response                  
        );    
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemResponseDto>> GetItem(int id)
    {
        try
        {
            var item = await _itemService.GetItemAsync(id);
            return Ok(item);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Item with id {id} not found");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemResponseDto>>> GetAllItems(
        [FromQuery] string? storeName = null,
        [FromQuery] bool? isPurchased = null)
    {
        var item = await _itemService.GetItemsAsync(storeName, isPurchased);
        return Ok(item);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ItemResponseDto>> UpdateItem(
        int id, 
        [FromBody] UpdateItemDto updateItemDto)
    {
        if (id != updateItemDto.Id)
            return BadRequest("Id mismatch");

        try
        {
            var item = await _itemService.UpdateItemAsync(updateItemDto);
            return Ok(item);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }    
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
        var success = await _itemService.DeleteItemAsync(id);
    
        if (!success)
            return NotFound($"Item with id {id} not found");
    
        return NoContent();  // 204 No Content - стандарт для DELETE
    }
}
