using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; } 
    public decimal TotalPrice => Quantity * UnitPrice;
    public Cart Cart { get; set; }
    public Product Product { get; set; }
}
