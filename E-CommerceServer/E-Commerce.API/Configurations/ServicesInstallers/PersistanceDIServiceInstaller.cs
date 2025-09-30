using E_Commerce.API.Configurations.Abstraction;
using E_Commerce.API.Middleware;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.MailService;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using E_Commerce.Domain.Repositories.UserAttributeRepositories;
using E_Commerce.Persistance.Repositories.CommerceAttributeRepositories;
using E_Commerce.Persistance.Repositories.UserAttributeRepositories;
using E_Commerce.Persistance.Services;
using E_Commerce.Persistance.Services.UserAttributeServices;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<ICartItemService, CartItemService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
}
