using E_Commerce.API.Configurations.Abstraction;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();
    }
}
