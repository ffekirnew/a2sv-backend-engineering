using CleanArchitectureBlogApi.Domain.Entities;

namespace CleanArchtectureBlogApi.Application.Contracts.Persistence;

public interface ICommentRepository : IGenericRepository<Comment>
{
    public Task<List<Comment>> GetAll(int postId);
}
