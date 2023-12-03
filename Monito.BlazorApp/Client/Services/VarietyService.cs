using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http.Json;

namespace Monito.BlazorApp.Client.Services
{
	public class VarietyService : IVarietyService
	{
		private readonly HttpClient _httpClient;

		public VarietyService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Variety>> GetVarieties()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Variety>>("api/variety");
		}

		public async Task<Variety> GetVariety(int id)
		{
			return await _httpClient.GetFromJsonAsync<Variety>($"api/variety/{id}");
		}

		public async Task CreateVariety(Variety variety)
		{
			await _httpClient.PostAsJsonAsync("api/variety", variety);
		}

		public async Task UpdateVariety(Variety variety)
		{
			await _httpClient.PutAsJsonAsync($"api/variety/{variety.Id}", variety);
		}

		public async Task DeleteVariety(Variety variety)
		{
			await _httpClient.DeleteAsync($"api/variety/{variety.Id}");
		}
	}
}
