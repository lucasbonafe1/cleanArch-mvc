using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();
        builder.Property(p => p.Stock).IsRequired();

        builder.Property(p => p.Image);

        builder.HasOne(h => h.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(f => f.CategoryId);
    }
}
