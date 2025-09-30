using E_Commerce.Domain.Entities.UserAttributeEntities;
using E_Commerce.Domain.Repositories.UserAttributeRepositories;
using E_Commerce.Persistance.Context;
using GenericRepository;

namespace E_Commerce.Persistance.Repositories.UserAttributeRepositories;

public sealed class AuthRepository : Repository<User, CommerceContext>, IAuthRepository
{
    public AuthRepository(CommerceContext context) : base(context) { }
}