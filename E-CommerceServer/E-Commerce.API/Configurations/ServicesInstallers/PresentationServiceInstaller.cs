using E_Commerce.API.Configurations.Abstraction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace E_Commerce.API.Configurations.ServicesInstallers;

public sealed class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed(policy => true));
        });

        services.AddControllers()
            .AddApplicationPart(typeof(E_Commerce.Presentation.AssemblyReference).Assembly)
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddSwaggerGen(setup =>
        {
            var jwtSecuritySheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
        });
    }
}
