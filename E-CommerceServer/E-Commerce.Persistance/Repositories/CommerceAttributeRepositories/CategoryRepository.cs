using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using E_Commerce.Persistance.Context;
using GenericRepository;

namespace E_Commerce.Persistance.Repositories.CommerceAttributeRepositories;

public sealed class CategoryRepository : Repository<Category, CommerceContext>, ICategoryRepository
{
    public CategoryRepository(CommerceContext context) : base(context) { }
}
