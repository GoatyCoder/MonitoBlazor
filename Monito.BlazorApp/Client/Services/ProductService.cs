using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http.Json;

namespace Monito.BlazorApp.Client.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;

		public ProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/product");
		}

		public async Task<Product> GetProductById(int id)
		{

			return await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
		}

		public async Task CreateProduct(Product product)
		{
			var response = await _httpClient.PostAsJsonAsync("api/product", product);
			//response.EnsureSuccessStatusCode();
		}

		public async Task UpdateProduct(Product product)
		{
			await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);
		}

		public async Task DeleteProduct(Product product)
		{
			await _httpClient.DeleteAsync($"api/product/{product.Id}");
		}

		public async Task<IEnumerable<Variety>> GetVarietiesByProductId(int productId)
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Variety>>($"api/product/{productId}/varieties");
		}

		public async Task<Product> GetByCode(string code)
		{
			return await _httpClient.GetFromJsonAsync<Product>($"api/product/code/{code}");
		}
	}
}
