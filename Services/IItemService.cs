using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingBuddy.Models.DTOs;

namespace ShoppingBuddy.Services;

public interface IItemService
{
    public Task<ItemResponseDto> CreateItemAsync(CreateItemDto itemDto);
    public Task<ItemResponseDto> UpdateItemAsync(UpdateItemDto itemDto);
    public Task<ItemResponseDto> GetItemAsync(int id);
    public Task<bool> DeleteItemAsync(int id);
    Task<IEnumerable<ItemResponseDto>> GetItemsAsync(
        string? storeName = null, 
        bool? isPurchased = null
    );
}