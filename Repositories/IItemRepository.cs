using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingBuddy.Models.Entities;

namespace ShoppingBuddy.Repositories;

public interface IItemRepository : IRepository<ShoppingItem>
{
    Task<IEnumerable<ShoppingItem>> GetItemsAsync(
        string? storeName = null,
        bool? isPurchased = null
    );
    public Task<ShoppingItem?> GetItemByIdWithStoreAsync(int id);
}