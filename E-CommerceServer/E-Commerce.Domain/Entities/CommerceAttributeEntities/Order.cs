using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class Order : BaseEntity
{
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
