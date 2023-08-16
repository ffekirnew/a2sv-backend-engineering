using CleanArchitectureBlogApi.Domain.Entities;

namespace CleanArchtectureBlogApi.Application.Contracts.Persistence;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
    public Task<List<BlogPost>> GetAll();
}
