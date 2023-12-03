using Microsoft.AspNetCore.Components;
using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;
using MudBlazor;

namespace Monito.BlazorApp.Client.Pages
{
	public partial class ProductsManager
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }
		[Inject]
		public IDialogService DialogService { get; set; }
		[Inject]
		public IProductService ProductService { get; set; }

		private string _searchString = "";
		private bool _isAddProductDialogVisible = false;
		private IEnumerable<Product> _products;
		private Product _newProduct = new();

		private async Task<IEnumerable<Variety>> LoadVarieties(int productId)
		{
			return await ProductService.GetVarietiesByProductId(productId);
		}

		private void OnAddProductClicked()
		{
			_isAddProductDialogVisible = true;
		}

		private async Task OnAddProduct()
		{
			try
			{
				await ProductService.CreateProduct(_newProduct);
				await LoadProducts();
				_isAddProductDialogVisible = false;
				_newProduct = new Product();
			}
			catch (HttpRequestException ex)
			{
				await DialogService.ShowMessageBox("Errore", $"Errore durante la richiesta HTTP: {ex.Message}");
			}
			catch (TaskCanceledException ex)
			{
				await DialogService.ShowMessageBox("Errore", $"Richiesta annullata: {ex.Message}");
			}
			catch (Exception ex)
			{
				await DialogService.ShowMessageBox("Errore", $"Errore durante la creazione del prodotto: {ex.Message}");
			}
		}

		private void OnCancelAddProduct()
		{
			_isAddProductDialogVisible = false;
			_newProduct = new Product();
		}

		private async Task OnDeleteProduct(Product productToDelete)
		{
			bool? confirmed = await DialogService.ShowMessageBox("Conferma eliminazione", "Sei sicuro di voler eliminare questo prodotto?", yesText: "Sì", noText: "No");
			if (confirmed == true)
			{
				await ProductService.DeleteProduct(productToDelete);
				await LoadProducts();
			}
		}

		// quick filter - filter gobally across multiple columns with the same input
		private Func<Product, bool> _quickFilter => x =>
		{
			if (string.IsNullOrWhiteSpace(_searchString))
				return true;

			if (x.Code.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
				return true;

			if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
				return true;

			return false;
		};

		private void OnVarietiesManager(Product product)
		{
			NavigationManager.NavigateTo($"/varieties-manager/{product.Id}");
		}

		private async Task LoadProducts()
		{
			_products = await ProductService.GetProducts();
		}

		protected override async Task OnInitializedAsync()
		{
			await LoadProducts();
		}
	}
}
