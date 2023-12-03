using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProducts();
		Task<Product> GetProductById(int id);
		Task CreateProduct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(Product product);
		Task<IEnumerable<Variety>> GetVarietiesByProductId(int id);
		Task<Product> GetByCode(string code);
	}
}
