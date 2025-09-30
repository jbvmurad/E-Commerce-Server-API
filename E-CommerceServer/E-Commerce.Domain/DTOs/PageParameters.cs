namespace E_Commerce.Domain.DTOs;

public sealed record PageParameters(
    int PageNumber=1,
    int PageSize=10);