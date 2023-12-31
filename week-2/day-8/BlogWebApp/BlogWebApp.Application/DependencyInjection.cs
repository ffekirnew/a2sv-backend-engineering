using BlogWebApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWebApp.Application;

public static class DependencyInjection {
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<PostsService>();
    services.AddScoped<CommentsService>();

    return services;
  }
}
