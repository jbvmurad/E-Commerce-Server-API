using E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.CreateRole;
using E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.DeleteRole;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace E_Commerce.Persistance.Services.UserAttributeServices;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = new()
        {
            Name = request.Name,
        };
        await _roleManager.CreateAsync(role);
    }

    public async Task DeleteAsync(DeleteRoleCommand request)
    {
        var role = await _roleManager.FindByIdAsync(request.Id.ToString());

        if (role is null)
            throw new ArgumentException($"Role with ID {request.Id} not found.");

        var result = await _roleManager.DeleteAsync(role);
    }
}
