using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchitectureBlogApi.Persistence;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtectureBlogApi.Persistence.Repositories;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepository(CleanArchitectureBlogApiDbContext dbContext)
        : base(dbContext) { }

    public async Task<List<BlogPost>> GetAll()
    {
      return await _dbContext.Set<BlogPost>().ToListAsync();
    }
}
