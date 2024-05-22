using System.Linq.Expressions;

namespace MutexDotCom.Data.Helper
{
    public interface IEntityBaseRepo<T> where T : class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,T entity);

    }
}
