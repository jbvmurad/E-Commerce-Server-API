using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ProductStatus Status { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
