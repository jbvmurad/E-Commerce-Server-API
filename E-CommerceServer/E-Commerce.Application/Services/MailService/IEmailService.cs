namespace E_Commerce.Application.Services.MailService;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string to, string subject, string body);
    Task<bool> SendVerificationEmailAsync(string to, string userId, string token);
    Task<bool> SendDeletionNotificationEmailAsync(string to);
}
