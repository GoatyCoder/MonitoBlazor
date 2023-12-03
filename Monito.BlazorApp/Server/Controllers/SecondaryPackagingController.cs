using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecondaryPackagingController : GenericController<SecondaryPackaging>
	{
		private readonly ISecondaryPackagingRepository _repository;

		public SecondaryPackagingController(ISecondaryPackagingRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}
