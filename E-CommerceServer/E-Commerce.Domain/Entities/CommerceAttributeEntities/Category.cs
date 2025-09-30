using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Entities.CommerceAttributeEntities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
