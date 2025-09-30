var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.E_Commerce_API>("e-commerce-api");

builder.Build().Run();