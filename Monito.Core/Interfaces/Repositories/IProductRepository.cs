using Monito.Core.Entities;

namespace Monito.Core.Interfaces.Repositories
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		IQueryable<Variety> GetVarieties(int productId);

		IQueryable<Product> GetByCode(string code);
	}
}
