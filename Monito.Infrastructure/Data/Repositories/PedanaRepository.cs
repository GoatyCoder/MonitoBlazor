using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class PedanaRepository : GenericRepository<Pedana>, IPedanaRepository
	{
		public PedanaRepository(MonitoDbContext context) : base(context)
		{
		}
	}
}
