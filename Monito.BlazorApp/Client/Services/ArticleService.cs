using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using System.Net.Http.Json;

namespace Monito.BlazorApp.Client.Services
{
	public class ArticleService : IArticleService
	{
		private readonly HttpClient _httpClient;

		public ArticleService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Article>> GetArticles()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Article>>("api/article");
		}

		public async Task<Article> GetArticleById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Article>($"api/article/{id}");
		}

		public async Task CreateArticle(Article article)
		{
			await _httpClient.PostAsJsonAsync("api/article", article);
		}

		public async Task UpdateArticle(Article article)
		{
			await _httpClient.PutAsJsonAsync($"api/article/{article.Id}", article);
		}

		public async Task DeleteArticle(Article article)
		{
			await _httpClient.DeleteAsync($"api/article/{article.Id}");
		}
	}
}
