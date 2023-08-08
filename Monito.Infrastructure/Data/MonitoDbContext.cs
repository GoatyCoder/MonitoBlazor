using Microsoft.EntityFrameworkCore;
using Monito.Core.Entities;

namespace Monito.Infrastructure.Data
{
	public class MonitoDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public MonitoDbContext(DbContextOptions<MonitoDbContext> options) : base(options)
		{

		}
	}
}
