using E_Commerce.Application.Services.MailService;
using E_Commerce.Domain.DTOs;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly EmailParameters _settings;

    public EmailService(EmailParameters settings)
    {
        _settings = settings;

        var sender = new SmtpSender(() => new SmtpClient(_settings.Host)
        {
            EnableSsl = _settings.EnableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Port = _settings.Port,
            Credentials = new NetworkCredential(_settings.Username, _settings.AppPassword)
        });

        Email.DefaultSender = sender;
    }


    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        var response = await Email
            .From(_settings.From)
            .To(to)
            .Subject(subject)
            .Body(body, isHtml: true)
            .SendAsync();

        return response.Successful;
    }

    public async Task<bool> SendVerificationEmailAsync(string to, string userId, string token)
    {
        var encodedToken = Uri.EscapeDataString(token);
        var verificationLink = $"https://your-frontend.com/verify-email?userId={userId}&token={encodedToken}";

        var body = $@"
           <h2>Welcome!</h2>
           <p>Please click the link below to verify your account:</p>
           <a href='{verificationLink}'>Verify My Account</a>
        ";

        return await SendEmailAsync(to, "Verify Your Account", body);
    }

    public async Task<bool> SendDeletionNotificationEmailAsync(string to)
    {
        var body = @"
           <h2>Your Account Has Been Deleted</h2>
           <p>Your account has been successfully deleted. Thank you for using our service.</p>
        ";

        return await SendEmailAsync(to, "Account Deletion Notice", body);
    }
}
