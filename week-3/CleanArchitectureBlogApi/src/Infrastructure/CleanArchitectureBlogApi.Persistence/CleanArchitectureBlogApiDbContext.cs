using CleanArchitectureBlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlogApi.Persistence;

public class CleanArchitectureBlogApiDbContext : DbContext
{
    private DbSet<BlogPost> BlogPosts { get; set; } = null!;
    private DbSet<Comment> Comments { get; set; } = null!;

    public CleanArchitectureBlogApiDbContext(
        DbContextOptions<CleanArchitectureBlogApiDbContext> options
    )
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CleanArchitectureBlogApiDbContext).Assembly
        );
        modelBuilder.Entity<Comment>(entity =>
        {
            entity
                .HasOne(c => c.BlogPost)
                .WithMany(bP => bP.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Comment_BlogPost");
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        {
            entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
