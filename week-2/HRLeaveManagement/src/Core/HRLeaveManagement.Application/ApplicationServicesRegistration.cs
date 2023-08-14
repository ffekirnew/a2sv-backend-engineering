using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigurationApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
