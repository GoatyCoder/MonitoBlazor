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

        public async Task<IEnumerable<Variety>> GetAllAsync()
        {
            try
            {
                var varieties = await _httpClient.GetFromJsonAsync<IEnumerable<Variety>>("api/Variety");
                return varieties;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Variety> GetByIdAsync(int id)
        {
            try
            {
                var variety = await _httpClient.GetFromJsonAsync<Variety>($"api/Variety/{id}");
                return variety;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddAsync(Variety entity)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Variety", entity);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Variety entity)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Variety/{entity.Id}", entity);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Variety entity)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Variety/{entity.Id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
