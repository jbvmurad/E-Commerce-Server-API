using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistance.Configurations.CommerceAttributeConfigurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}