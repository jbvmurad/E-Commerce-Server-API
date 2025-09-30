using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetUserById;

public sealed record GetUserByIdQuery(
    int Id) :IRequest<UserParameters>;