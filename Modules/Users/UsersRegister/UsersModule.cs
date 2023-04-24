using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using mustafarbackend.config;
using mustafarbackend.Modules.Auth.Implementations;
using mustafarbackend.Repository;
using Mustafarbackend.Modules.Users.Interfaces.Services;
using Mustafarbackend.Modules.Users.Services;

public class UsersModules : IModule
{
    static public readonly string policyNameRateLimiting = "nameRateLimiting";

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserImplementation>();

        return services;
    }
}

