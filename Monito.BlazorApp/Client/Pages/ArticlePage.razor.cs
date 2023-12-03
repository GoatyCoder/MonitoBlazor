using Microsoft.AspNetCore.Components;
using Monito.BlazorApp.Client.Services;
using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace Monito.BlazorApp.Client.Pages
{
    public partial class ArticlePage
    {
        [Inject]
        public IArticleService ArticleService { get; set; }
		[Inject]
		public IProductService ProductService { get; set; }

		private bool _isAddDialogOpen = false;
		private string searchString = "";
		private Article selectedItem = null;
		private Article _newArticle = new();
		private IEnumerable<Article> _articles;
		private IEnumerable<Product> _products;

		private void AddProduct()
		{
			_isAddDialogOpen = true;
		}

		private async Task SaveAdd()
		{
			await ArticleService.CreateArticle(_newArticle);
			_articles = await ArticleService.GetArticles();
			_isAddDialogOpen = false;
			_newArticle = new Article();
		}

		private void CancelAdd()
		{
			_isAddDialogOpen = false;
			_newArticle = new Article();
		}

		private bool FilterFunc1(Article article) => FilterFunc1(article, searchString);

		private bool FilterFunc1(Article article, string searchString)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return true;
			if (article.Code.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (article.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			return false;
		}

		protected override async Task OnInitializedAsync()
        {
            _articles = await ArticleService.GetArticles();
			_products = await ProductService.GetProducts();

			//i prodotti vengono caricati solo all'inizializzazione della pagina
		}
    }
}
