using CleanArchitectureBlogApi.Domain.Entities;

namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface ICommentRepository : IGenericRepository<Comment>
{
    public Task<List<Comment>> GetAll(int postId);
}
