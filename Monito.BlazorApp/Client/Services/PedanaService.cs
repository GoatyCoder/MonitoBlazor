using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http.Json;

namespace Monito.BlazorApp.Client.Services
{
	public class PedanaService : IPedanaService
	{
		private readonly HttpClient _httpClient;

		public PedanaService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Pedana>> GetAll()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Pedana>>("api/pedana");
		}

		public async Task<Pedana> GetById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Pedana>($"api/pedana/{id}");
		}

		public async Task Create(Pedana pedana)
		{
			await _httpClient.PostAsJsonAsync("api/pedana", pedana);
		}

		public async Task Update(Pedana pedana)
		{
			await _httpClient.PutAsJsonAsync($"api/pedana/{pedana.Id}", pedana);
		}

		public async Task Delete(int id)
		{
			await _httpClient.DeleteAsync($"api/pedana/{id}");
		}
	}
}
