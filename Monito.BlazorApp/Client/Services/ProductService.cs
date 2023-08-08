using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http;
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

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			try
			{
				var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product");
				return products;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<Product> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
		public Task AddAsync(Product entity)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Product entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}
