using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Entities.UserAttributeEntities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; } 
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
