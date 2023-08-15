using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddAppcation(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
