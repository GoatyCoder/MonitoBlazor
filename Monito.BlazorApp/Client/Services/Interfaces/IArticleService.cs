using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface IArticleService
	{
		Task<IEnumerable<Article>> GetArticles();
		Task<Article> GetArticleById(int id);
		Task CreateArticle(Article article);
		Task UpdateArticle(Article article);
		Task DeleteArticle(Article article);
	}
}
