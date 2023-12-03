using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http.Json;

namespace Monito.BlazorApp.Client.Services
{
	public class SecondaryPackagingService : ISecondaryPackagingService
	{
		private readonly HttpClient _httpClient;

		public SecondaryPackagingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<SecondaryPackaging>> GetPackagings()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<SecondaryPackaging>>("api/secondarypackaging");
		}

		public async Task<SecondaryPackaging> GetPackaging(int id)
		{
			return await _httpClient.GetFromJsonAsync<SecondaryPackaging>($"api/secondarypackaging/{id}");
		}

		public async Task CreatePackaging(SecondaryPackaging packaging)
		{
			await _httpClient.PostAsJsonAsync("api/secondarypackaging", packaging);
		}

		public async Task UpdatePackaging(SecondaryPackaging packaging)
		{
			await _httpClient.PutAsJsonAsync($"api/secondarypackaging/{packaging.Id}", packaging);
		}

		public async Task DeletePackaging(SecondaryPackaging packaging)
		{
			await _httpClient.DeleteAsync($"api/secondarypackaging/{packaging.Id}");
		}
	}
}
