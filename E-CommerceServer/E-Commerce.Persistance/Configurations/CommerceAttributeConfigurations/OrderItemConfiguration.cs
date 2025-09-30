using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistance.Configurations.CommerceAttributeConfigurations;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(x => x.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}