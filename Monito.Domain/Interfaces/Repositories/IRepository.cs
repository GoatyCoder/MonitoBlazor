using Monito.Domain.Entities;
using System.Linq.Expressions;

namespace Monito.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> CountAsync();
    }
}
