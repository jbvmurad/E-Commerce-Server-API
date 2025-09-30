using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Entities.UserAttributeEntities;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
