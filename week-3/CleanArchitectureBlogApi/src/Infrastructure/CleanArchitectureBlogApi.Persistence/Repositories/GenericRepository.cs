using CleanArchitectureBlogApi.Persistence;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;

namespace CleanArchtectureBlogApi.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected CleanArchitectureBlogApiDbContext _dbContext;

    public GenericRepository(CleanArchitectureBlogApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Create(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _dbContext.FindAsync<T>(id)!;
        _dbContext.Set<T>().Remove(entity!);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }

    public async Task<T> Get(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity!;
    }

    public Task Update(int id, T entity)
    {
        var dbEntity = Get(id);
        _dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
        return _dbContext.SaveChangesAsync();
    }
}
