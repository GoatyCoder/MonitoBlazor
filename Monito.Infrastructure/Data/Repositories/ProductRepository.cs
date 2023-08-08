using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(MonitoDbContext context) : base(context)
		{
		}
	}
}
