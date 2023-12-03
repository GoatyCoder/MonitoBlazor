using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PedanaController : GenericController<Pedana>
	{
		private readonly IPedanaRepository _repository;

		public PedanaController(IPedanaRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}
