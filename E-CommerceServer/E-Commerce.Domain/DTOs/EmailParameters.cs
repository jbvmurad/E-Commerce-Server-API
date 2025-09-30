namespace E_Commerce.Domain.DTOs;

public sealed record EmailParameters(
    string Host,
    int Port,
    bool EnableSsl,
    string From,
    string Username,
    string AppPassword);
