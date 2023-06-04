using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalSystem.DataAccessLayer;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<T>? AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>?> AddRange(IEnumerable<T> entities)
    {
        var entitiesList = entities.ToList();
        await _context.Set<T>().AddRangeAsync(entitiesList);
        return entities;
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }

    public Task<int> CountAsyncWhere(Expression<Func<T, bool>> Filter)
    {
        return _context.Set<T>().CountAsync(Filter);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>?> GetAllAsyn()
   => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsyn(int id)
    => await _context.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>?> GetWith(Expression<Func<T, bool>>? Filter = null, string[]? Includes = null)
    {

        IQueryable<T> query = _context.Set<T>();
        if (Filter != null)
        {
            query = query.Where(Filter);
        }

        if (Includes != null)
        {
            foreach (var item in Includes)
            {
                query = query.Include(item);
            }
        }
        return await query.ToListAsync();


    }


    public T? Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;

    }
}
