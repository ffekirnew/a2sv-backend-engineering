using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchitectureBlogApi.Persistence;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtectureBlogApi.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(CleanArchitectureBlogApiDbContext dbContext)
        : base(dbContext) { }

    public async Task<List<Comment>> GetAll(int postId)
    {
        return await _dbContext.Set<Comment>().Where(c => c.PostId == postId).ToListAsync();
    }
}
