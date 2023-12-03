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
			try
			{
				return await _dbSet.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException("Errore durante il recupero di tutti gli elementi", ex);
			}
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			try
			{
				return await _dbSet.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Errore durante il recupero dell'elemento con ID {id}", ex);
			}
		}

		public async Task AddAsync(TEntity entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException("Errore durante l'aggiunta di un nuovo elemento", ex);
			}
		}

		public async Task UpdateAsync(TEntity entity)
		{
			try
			{
				_dbSet.Update(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException("Errore durante l'aggiornamento di un elemento esistente", ex);
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				var entity = await GetByIdAsync(id);
				if (entity == null)
				{
					throw new RepositoryException($"Nessun elemento trovato con ID {id}");
				}

				_dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Errore durante l'eliminazione dell'elemento con ID {id}", ex);
			}
		}
	}

	public class RepositoryException : Exception
	{
		public RepositoryException(string message) : base(message) { }
		public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
	}
}
