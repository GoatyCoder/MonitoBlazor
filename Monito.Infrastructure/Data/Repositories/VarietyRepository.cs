using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class VarietyRepository : GenericRepository<Variety>, IVarietyRepository
	{
		public VarietyRepository(MonitoDbContext context) : base(context)
		{
		}
	}
}
