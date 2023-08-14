namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface IGenericRepository<T>
{
    public void Create(T entity);
    public Task<T> Get(int id);
    public void Update(int id, T entity);
    public void Delete(int id);
}
