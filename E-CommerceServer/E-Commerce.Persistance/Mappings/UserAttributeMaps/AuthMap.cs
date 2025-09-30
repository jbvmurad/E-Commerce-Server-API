using AutoMapper;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.UserAttributeEntities;

namespace E_Commerce.Persistance.Mappings.UserAttributeMaps;

public sealed class AuthMap :Profile
{
    public AuthMap()
    {
        CreateMap<RegisterUserCommand,User>().ReverseMap();
        CreateMap<UpdateUserCommand,User>().ReverseMap();
        CreateMap<UserParameters,User>().ReverseMap();
    }
}
