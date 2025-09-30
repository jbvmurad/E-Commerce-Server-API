using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.GiveUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using E_Commerce.Domain.Repositories.UserAttributeRepositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Services.UserAttributeServices
{
    public sealed class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task GiveAsync(GiveUserRoleCommand request, CancellationToken cancellationToken)
        {
            bool roleAlreadyAssigned = await _userRoleRepository.AnyAsync(
                ur => ur.UserId == request.UserId && ur.RoleId == request.RoleId,
                cancellationToken
            );

            if (roleAlreadyAssigned)
            {
                throw new InvalidOperationException("This role has already been assigned to this user.");
            }

            var userRole = new UserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            await _userRoleRepository.AddAsync(userRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedList<UserRole>> GetAllAsync(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            var query = _userRoleRepository.GetAll(); 

            var count = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((request.PageParameters.PageNumber - 1) * request.PageParameters.PageSize)
                .Take(request.PageParameters.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedList<UserRole>(items, count, request.PageParameters.PageNumber, request.PageParameters.PageSize);
        }

        public async Task DeleteAsync(DeleteUserRoleFullCommand request, CancellationToken cancellationToken)
        {
            var userRoles = await _userRoleRepository
                .Where(ur => ur.UserId == request.UserId && request.RoleIds.Contains(ur.RoleId))
                .ToListAsync(cancellationToken);

            if (userRoles == null || userRoles.Count == 0)
            {
                throw new InvalidOperationException("No matching roles found for the given user.");
            }

            foreach (var userRole in userRoles)
            {
                _userRoleRepository.Delete(userRole);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
