using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class ArticleRepository : GenericRepository<Article>, IArticleRepository
	{
		public ArticleRepository(MonitoDbContext context) : base(context)
		{
		}
	}
}
