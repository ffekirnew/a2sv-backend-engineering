namespace CleanArchtectureBlogApi.Application.Persistence.Contract;

public interface IGenericRepository<T>
{
    public void Create(T entity);
    public T Get(int id);
    public List<T> GetAll();
    public void Update(int id, T entity);
    public void Delete(int id);
}
