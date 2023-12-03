using Monito.Domain.Entities;

namespace Monito.Blazor.Shared.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAll();
		Task<Product> GetById(int id);
		Task Add(Product product);
		Task Update(Product product);
		Task Delete(Product product);
		Task<IEnumerable<Variety>> GetVarietiesByProductId(int id);
	}
}
