namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface IGenericRepository<T>
{
    public Task<T> Create(T entity);
    public Task<T> Get(int id);
    public Task<bool> Exists(int id);
    public Task Update(int id, T entity);
    public Task Delete(int id);
}
