using E_Commerce.API.Configurations.Abstraction;
using E_Commerce.Application.Behavior;
using FluentValidation;
using MediatR;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddMediatR(cfg =>
           cfg.RegisterServicesFromAssembly(typeof(E_Commerce.Application.AssemblyReference).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(E_Commerce.Application.AssemblyReference).Assembly);
    }
}