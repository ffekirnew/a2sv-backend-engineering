using CleanArchitectureBlogApi.Domain.Entities;

namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
    public Task<List<BlogPost>> GetAll();
}
