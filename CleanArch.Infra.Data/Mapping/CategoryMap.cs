using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasMany(h => h.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(f => f.CategoryId);

        builder.HasData(new Category(1, "Casual"),
            new Category(2, "Esporte"),
            new Category(3, "Formal"));
    }
}
