using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VarietyController : GenericController<Variety>
	{
		private readonly IVarietyRepository _repository;

		public VarietyController(IVarietyRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}
