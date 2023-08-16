using CleanArchitectureBlogApi.Persistence;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using CleanArchtectureBlogApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchtectureBlogApi.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<CleanArchitectureBlogApiDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("CleanArchtectureBlogApiDbConnectionString")
            );
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }
}
