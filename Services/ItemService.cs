using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBuddy.Models.DTOs;
using ShoppingBuddy.Models.Entities;
using ShoppingBuddy.Repositories;

namespace ShoppingBuddy.Services;

public class ItemService(IItemRepository itemRepository,
    IStoreRepository storeRepository) : IItemService
{
    public async Task<ItemResponseDto> CreateItemAsync(CreateItemDto itemDto)
    {
        int? storeId = null;
        
        if (itemDto.Store != null)
        {
            var store = await storeRepository.GetByNameAsync(itemDto.Store);

            if (store == null)
            {
                storeId = await storeRepository.AddAsync(new Store { Name = itemDto.Store });
            }
            else
            {
                storeId = store.Id;
            }
        }

        var newItem = new ShoppingItem
        {
            Name = itemDto.Name,
            Quantity = itemDto.Quantity,
            StoreId = storeId,
            IsPurchased = false,
            CreatedAt = DateTime.UtcNow
        };
        
        var itemId = await itemRepository.AddAsync(newItem);
        var savedItem = await itemRepository.GetItemByIdWithStoreAsync(itemId);

        if (savedItem == null)
            throw new InvalidOperationException("Failed to retrieve created item");

        return new ItemResponseDto
        {
            Id =  savedItem.Id,
            Name = savedItem.Name,
            Store = savedItem.Store?.Name,
            Quantity = savedItem.Quantity,
            IsPurchased = savedItem.IsPurchased
        };
    }

    public async Task<ItemResponseDto> UpdateItemAsync(UpdateItemDto updateDto)
    {
        var existingItem = await itemRepository.GetItemByIdWithStoreAsync(updateDto.Id);
        if (existingItem == null)
            throw new KeyNotFoundException($"Item with id {updateDto.Id} not found");

        if (updateDto.Name != null)
            existingItem.Name = updateDto.Name;

        if (updateDto.Quantity != null)
            existingItem.Quantity = updateDto.Quantity.Value;

        if (updateDto.IsPurchased != null)
        {
            existingItem.IsPurchased = updateDto.IsPurchased.Value;
        
            if (updateDto.IsPurchased.Value)
                existingItem.PurchasedAt = DateTime.UtcNow;
        }

        if (updateDto.Store != null)
        {
            var store = await storeRepository.GetByNameAsync(updateDto.Store);
        
            if (store == null)
            {
                existingItem.StoreId = await storeRepository.AddAsync(new Store { Name = updateDto.Store });
            }
            else
            {
                existingItem.StoreId = store.Id;
            }
        }

        await itemRepository.UpdateAsync(existingItem);

        var updatedItem = await itemRepository.GetItemByIdWithStoreAsync(updateDto.Id);
        if (updatedItem == null)
            throw new InvalidOperationException("Failed to retrieve updated item");

        return new ItemResponseDto
        {
            Name = updatedItem.Name,
            Store = updatedItem.Store?.Name,
            Quantity = updatedItem.Quantity,
            IsPurchased = updatedItem.IsPurchased
        };
    }
    
    public async Task<ItemResponseDto> GetItemAsync(int id)
    {
        var item = await itemRepository.GetItemByIdWithStoreAsync(id);
        if (item == null)
            throw new KeyNotFoundException($"Item with id {id} not found");

        return new ItemResponseDto
            {
                Name = item.Name, 
                Store = item.Store?.Name, 
                Quantity = item.Quantity, 
                IsPurchased = item.IsPurchased};
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        return await itemRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ItemResponseDto>> GetItemsAsync(string? storeName = null, bool? isPurchased = null)
    {
        var items = await itemRepository.GetItemsAsync(storeName, isPurchased);

        return items.Select(i => new ItemResponseDto
        {
            Name = i.Name,
            Quantity = i.Quantity,
            Store = i.Store?.Name,
            IsPurchased = i.IsPurchased
        });
    }
}