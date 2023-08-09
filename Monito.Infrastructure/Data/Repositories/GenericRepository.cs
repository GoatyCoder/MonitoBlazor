using Microsoft.EntityFrameworkCore;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
	{
		protected readonly MonitoDbContext _context;
		protected readonly DbSet<TEntity> _dbSet;

		public GenericRepository(MonitoDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(TEntity entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntity entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
