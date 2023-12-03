using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : GenericController<Product>
	{
		private readonly IProductRepository _repository;

		public ProductController(IProductRepository repository) : base(repository)
		{
			_repository = repository;
		}


		[HttpGet("{productId}/varieties")]
		public async Task<ActionResult<IEnumerable<Variety>>> GetVarieties(int productId)
		{
			try
			{
				var varieties = _repository.GetVarieties(productId);
				return Ok(varieties);
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante il recupero delle varietà: {ex.Message}");
			}
		}

		[HttpGet("code/{code}")]
		public async Task<ActionResult<Product>> GetByCode(string code)
		{
			try
			{
				var product = _repository.GetByCode(code);
				return Ok(product);
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante il recupero del prodotto con codice {code}: {ex.Message}");
			}
		}
	}
}
