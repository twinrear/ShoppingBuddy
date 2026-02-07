using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.Data;
using ShoppingBuddy.Models.Entities;

namespace ShoppingBuddy.Repositories;

public class StoreRepository(AppDbContext db) : Repository<Store>(db), IStoreRepository
{
    public async Task<Store?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
    }
}