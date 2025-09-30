using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
