using CleanArchitectureBlogApi.Domain.Entities;

namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface ICommentRepository : IGenericRepository<Comment>
{
    public List<Comment> GetAllCommentsOfPost(int postId);
}
