using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistance.Configurations.CommerceAttributeConfigurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.ShippingAddress)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}