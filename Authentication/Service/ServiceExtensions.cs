using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Abstraction;

namespace Services;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}