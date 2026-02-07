using System.Threading.Tasks;
using ShoppingBuddy.Models.Entities;

namespace ShoppingBuddy.Repositories;

public interface IStoreRepository : IRepository<Store>
{
    Task<Store?> GetByNameAsync(string name);
}