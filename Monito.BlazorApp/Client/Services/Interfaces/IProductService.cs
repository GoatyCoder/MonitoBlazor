using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(int id);
		Task AddAsync(Product entity);
		Task UpdateAsync(Product entity);
		Task DeleteAsync(Product entity);
	}
}
