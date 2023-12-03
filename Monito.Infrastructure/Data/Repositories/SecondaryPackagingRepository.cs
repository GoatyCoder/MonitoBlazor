using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.Infrastructure.Data.Repositories
{
	public class SecondaryPackagingRepository : GenericRepository<SecondaryPackaging>, ISecondaryPackagingRepository
	{
		public SecondaryPackagingRepository(MonitoDbContext context) : base(context)
		{
		}
	}
}
