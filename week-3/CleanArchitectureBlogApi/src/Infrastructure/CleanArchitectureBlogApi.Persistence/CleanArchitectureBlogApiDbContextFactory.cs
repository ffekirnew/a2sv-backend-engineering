using CleanArchitectureBlogApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CleanArchtectureBlogApi.Persistence;

public class CleanArchitectureBlogApiDbContextFactory
    : IDesignTimeDbContextFactory<CleanArchitectureBlogApiDbContext>
{
    public CleanArchitectureBlogApiDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString(
            "CleanArchtectureBlogApiDbConnectionString"
        );

        var optionsBuilder = new DbContextOptionsBuilder<CleanArchitectureBlogApiDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new CleanArchitectureBlogApiDbContext(optionsBuilder.Options);
    }
}
