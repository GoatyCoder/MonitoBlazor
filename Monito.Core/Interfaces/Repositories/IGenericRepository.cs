using Monito.Core.Entities;

namespace Monito.Core.Interfaces.Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : EntityBase
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(int id);
		Task AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(int id);
	}
}
