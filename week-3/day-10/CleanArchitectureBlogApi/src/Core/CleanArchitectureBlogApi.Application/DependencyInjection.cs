using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServicesRegistration
{
    public static void AddAppcation(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
