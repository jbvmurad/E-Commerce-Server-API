using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistance.Configurations.CommerceAttributeConfigurations;

public sealed class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Carts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.CartItems)
            .WithOne(x => x.Cart)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}