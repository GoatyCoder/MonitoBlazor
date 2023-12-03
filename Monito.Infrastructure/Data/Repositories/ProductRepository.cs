using Microsoft.EntityFrameworkCore;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(MonitoDbContext context) : base(context)
		{
		}

		public IQueryable<Variety> GetVarieties(int productId)
		{
			return _context.Varieties.Where(v => v.ProductId == productId);
		}

		public IQueryable<Product> GetByCode(string code)
		{
			return _context.Products.Where(p => p.Code == code);
		}
	}
}
