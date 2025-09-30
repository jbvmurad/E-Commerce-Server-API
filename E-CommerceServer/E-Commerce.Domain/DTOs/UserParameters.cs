namespace E_Commerce.Domain.DTOs;

public sealed record UserParameters(
    string FirstName,
    string LastName,
    string Email,
    string UserName);
