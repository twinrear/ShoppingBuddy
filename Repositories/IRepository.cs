using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBuddy.Repositories;

public interface IRepository<T> where T : class
{
    public Task<int> AddAsync(T entity);
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(int id);
}