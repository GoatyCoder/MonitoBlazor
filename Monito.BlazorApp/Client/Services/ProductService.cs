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

		public async Task<Product> GetByIdAsync(int id)
		{
            try
            {
                var product = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

		public async Task AddAsync(Product entity)
		{
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Product", entity);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

		public async Task UpdateAsync(Product entity)
		{
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Product/{entity.Id}", entity);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

		public async Task DeleteAsync(Product entity)
		{
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Product/{entity.Id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
	}
}
