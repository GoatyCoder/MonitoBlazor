using Microsoft.EntityFrameworkCore;
using Monito.Domain.Entities;
using Monito.Domain.Interfaces.Repositories;
using Monito.Infrastructure.Data;

namespace Monito.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MonitoDbContext context) : base(context) { }

        public async Task<IEnumerable<Variety>> GetVarieties(int productId)
        {
            return _context.Varieties.Where(v => v.ProductId == productId);
        }
    }
}
