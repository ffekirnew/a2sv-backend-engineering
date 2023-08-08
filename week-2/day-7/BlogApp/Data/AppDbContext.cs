using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Comment_Post");
        });

        // modelBuilder.Entity<Post>(entity => {
        //     entity
        //     .HasMany(p => p.Comments)
        //     .WithOne( c => c.Post)
        //     .OnDelete(DeleteBehavior.Cascade)
        //     .HasConstraintName("")
        //     });
    }
}
