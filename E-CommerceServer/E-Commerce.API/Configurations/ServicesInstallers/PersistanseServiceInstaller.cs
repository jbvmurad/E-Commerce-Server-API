using E_Commerce.API.Configurations.Abstraction;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using E_Commerce.Persistance.Context;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class PersistanseServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        var connectionString = configuration.GetConnectionString("CommerceConnection");

        services.AddDbContext<CommerceContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<CommerceContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<CommerceContext>());

        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(E_Commerce.Persistance.AssemblyReference).Assembly);
        });

        var sinkOptions = new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        };

        var columnOptions = new ColumnOptions();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: connectionString,
                sinkOptions: sinkOptions,
                columnOptions: columnOptions
            )
            .CreateLogger();

        host.UseSerilog();
    }
}
