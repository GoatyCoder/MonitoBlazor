using Microsoft.EntityFrameworkCore;
using Monito.Domain.Entities;
using Monito.Infrastructure.Data.Config;

namespace Monito.Infrastructure.Data
{
    public class MonitoDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Variety> Varieties { get; set; }

        public MonitoDbContext() { }

        public MonitoDbContext(DbContextOptions<MonitoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
