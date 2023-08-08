using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : GenericController<Product>
	{
		public ProductsController(IProductRepository repository) : base(repository)
		{
		}
	}
}
