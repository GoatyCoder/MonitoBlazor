using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Pages
{
	public partial class PalletManager
	{
		[Inject]
		public IPedanaService PedanaService { get; set; }
		[Inject]
		public IProductService ProductService { get; set; }

		private bool _isAddDialogOpen = true;
		private Pedana _newPedana = new();
		private IEnumerable<Pedana> _pedane;
		private string _productCode;
		private string _productName;

		private void AddPedana()
		{
			_isAddDialogOpen = true;
		}

		private async Task SaveAdd()
		{
			await PedanaService.Create(_newPedana);
			_pedane = await PedanaService.GetAll();
			_isAddDialogOpen = false;
			_newPedana = new();
		}

		private void CancelAdd()
		{
			_isAddDialogOpen = false;
			_newPedana = new();
		}

		private async Task UpdateProduct(ChangeEventArgs e)
		{
			var code = e.Value.ToString();
			var product = await ProductService.GetByCode(code);

			if (product != null)
			{
				_productName = product.Name;
				_newPedana.ProductId = product.Id;
			}
			else
			{
				_productName = "Nessun prodotto trovato";
			}
		}

		private async Task OnKeyDown(KeyboardEventArgs e)
		{
			if (e.Key == "Enter")
			{
				await UpdateProduct2();
			}
		}

		private async Task UpdateProduct2()
		{
			var code = _productCode;
			var product = await ProductService.GetByCode(code);

			if (product != null)
			{
				_productName = product.Name;
				_newPedana.ProductId = product.Id;
			}
			else
			{
				_productName = "Nessun prodotto trovato";

			}
		}

		protected override async Task OnInitializedAsync()
		{
			_pedane = await PedanaService.GetAll();
		}
	}
}