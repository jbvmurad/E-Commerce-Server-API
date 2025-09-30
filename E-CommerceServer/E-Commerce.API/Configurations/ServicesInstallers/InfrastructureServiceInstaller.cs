using E_Commerce.API.Configurations.Abstraction;
using E_Commerce.API.OptionsSetup;
using E_Commerce.Application.Abstractions;
using E_Commerce.Domain.DTOs;
using E_Commerce.Infrastructure.Authentication;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        var emailParams = configuration
           .GetSection("EmailParameters")
           .Get<EmailParameters>();

        services.AddSingleton(emailParams);

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetups>();
    }
}
