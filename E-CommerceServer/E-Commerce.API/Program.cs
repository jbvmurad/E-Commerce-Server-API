using E_Commerce.API.Configurations;
using E_Commerce.API.Configurations.Abstraction;
using E_Commerce.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(
    builder.Configuration,
    builder.Host,
    typeof(IServiceInstaller).Assembly);

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API V1"));
}

app.UseCors();
app.UseMiddlewareExtensions();
app.MapControllers();

app.Run();
