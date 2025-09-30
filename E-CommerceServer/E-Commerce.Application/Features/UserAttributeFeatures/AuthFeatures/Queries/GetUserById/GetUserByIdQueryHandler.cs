using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserParameters>
{
    private readonly IAuthService _authService;

    public GetUserByIdQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<UserParameters> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _authService.GetByIdAsync(request,cancellationToken);
    }
}
