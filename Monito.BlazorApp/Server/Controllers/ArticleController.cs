using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : GenericController<Article>
	{
		private readonly IArticleRepository _repository;

		public ArticleController(IArticleRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}
