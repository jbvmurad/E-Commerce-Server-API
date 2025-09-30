﻿namespace E_Commerce.API.Configurations.Abstraction;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host);
}
