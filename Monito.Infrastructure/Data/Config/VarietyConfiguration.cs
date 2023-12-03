using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monito.Domain.Entities;

namespace Monito.Infrastructure.Data.Config
{
    public class VarietyConfiguration : IEntityTypeConfiguration<Variety>
    {
        public void Configure(EntityTypeBuilder<Variety> builder)
        {
            builder.HasKey(v => new { v.ProductId, v.Code });
            builder.HasKey(v => new { v.ProductId, v.Name });

            builder.Property(v => v.Name).IsRequired().HasMaxLength(255);
            builder.Property(v => v.Code).IsRequired().HasMaxLength(8);
        }
    }
}
