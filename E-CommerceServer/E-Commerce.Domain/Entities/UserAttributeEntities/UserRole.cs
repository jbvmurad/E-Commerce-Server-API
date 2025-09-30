using E_Commerce.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Entities.UserAttributeEntities;

public sealed class UserRole :BaseEntity
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
