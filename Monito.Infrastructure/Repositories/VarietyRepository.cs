using Monito.Domain.Entities;
using Monito.Domain.Interfaces.Repositories;
using Monito.Infrastructure.Data;

namespace Monito.Infrastructure.Repositories
{
    public class VarietyRepository : Repository<Variety>, IVarietyRepository
    {
        public VarietyRepository(MonitoDbContext context) : base(context) { }
    }
}
