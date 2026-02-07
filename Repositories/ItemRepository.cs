using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.Data;
using ShoppingBuddy.Models.Entities;

namespace ShoppingBuddy.Repositories;

public class ItemRepository(AppDbContext db) : Repository<ShoppingItem>(db), IItemRepository
{
    public async Task<IEnumerable<ShoppingItem>> GetItemsAsync(
        string? storeName = null, 
        bool? isPurchased = null)
    {
        IQueryable<ShoppingItem> query = _dbSet.Include(x => x.Store);
        
        if (storeName != null)
            query = query.Where(x => x.Store.Name == storeName);
        
        if (isPurchased != null)
            query = query.Where(x => x.IsPurchased == isPurchased);
        
        return await query.ToListAsync();
    }

    public async Task<ShoppingItem?> GetItemByIdWithStoreAsync(int id)
    {
        IQueryable<ShoppingItem> query = _dbSet.Include(x => x.Store);
        query = query.Where(x => x.Id == id);
        return await query.FirstOrDefaultAsync();
    }
}
