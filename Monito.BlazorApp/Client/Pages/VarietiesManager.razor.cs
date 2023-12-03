using Microsoft.AspNetCore.Components;
using Monito.BlazorApp.Client.Services.Interfaces;
using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Pages
{
	public partial class VarietiesManager
	{
		[Parameter]
		public int ProductId { get; set; }

		[Inject]
		public IProductService ProductService { get; set; }
        [Inject]
        public IVarietyService VarietyService { get; set; }

        private IEnumerable<Variety> _varieties;
        private string _searchString = "";
        private bool _isAddVarietyDialogVisible = false;
        private Variety _newVariety = new();
        private Product _product;

        private void OnAddVarietyClicked()
        {
            _isAddVarietyDialogVisible = true;
        }

        private async Task OnAddVariety()
        {
            _newVariety.ProductId = ProductId;
            await VarietyService.CreateVariety(_newVariety);
            _varieties = await ProductService.GetVarietiesByProductId(ProductId);
            _isAddVarietyDialogVisible = false;
            _newVariety = new();
        }

        private void OnCancelAddVariety()
        {
            _isAddVarietyDialogVisible = false;
            _newVariety = new()
            {
                ProductId = _product.Id,
            };
        }

        private async Task OnDeleteVariety(Variety varietyToDelete)
        {
            // Elimina la varietà dal database
            await VarietyService.DeleteVariety(varietyToDelete);

            // Aggiorna la lista delle varietà visualizzate nella pagina
            _varieties = await ProductService.GetVarietiesByProductId(ProductId);
        }

        // quick filter - filter gobally across multiple columns with the same input
        private Func<Variety, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Code.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        protected override async Task OnInitializedAsync()
        {
            _product = await ProductService.GetProductById(ProductId);
            _varieties = await ProductService.GetVarietiesByProductId(ProductId);
        }
    }
}
