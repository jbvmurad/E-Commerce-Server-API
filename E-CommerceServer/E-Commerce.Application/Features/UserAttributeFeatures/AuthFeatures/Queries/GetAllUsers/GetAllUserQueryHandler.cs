using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetAllUsers;

public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, PagedList<UserParameters>>
{
    private readonly IAuthService _authService;

    public GetAllUserQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<PagedList<UserParameters>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
         return await _authService.GetAllAsync(request, cancellationToken);
      
    }
}
