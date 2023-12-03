using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monito.Domain.Entities;

namespace Monito.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(8);
        }
    }
}
