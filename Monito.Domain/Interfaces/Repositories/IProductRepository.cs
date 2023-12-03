using Monito.Domain.Entities;

namespace Monito.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Variety>> GetVarieties(int productId);
    }
}
