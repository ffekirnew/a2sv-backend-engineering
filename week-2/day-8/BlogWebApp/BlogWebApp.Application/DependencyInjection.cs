using Microsoft.Extensions.DependencyInjection;

namespace BlogWebApp.Application;

public static class DependencyInjection {
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<PostsApplication>();
    services.AddScoped<CommentsApplication>();

    return services;
  }
}
