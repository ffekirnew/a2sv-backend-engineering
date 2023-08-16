using CleanArchtectureBlogApi.Application.Contracts.Infrastructure;
using CleanArchtectureBlogApi.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlogApi.Infrastructure;


public static class InfrastructureServicesRegistration
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
    services.AddTransient<IEmailSender, EmailSender>();

    return services;
  }
}
