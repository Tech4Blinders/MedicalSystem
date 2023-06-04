using System.Linq.Expressions;

namespace MedicalSystem.DataAccessLayer;
public interface IGenericRepo<T> where T : class
{
    public Task<IEnumerable<T>?> GetAllAsyn();
    public Task<T?> GetByIdAsyn(int id);

    public Task<T>? AddAsync(T entity);

    public T? Update(T entity);

    public void Delete(T entity);

    public Task<IEnumerable<T>?> GetWith(Expression<Func<T, bool>>? Filter = null, string[]? Includes = null);

    public Task<IEnumerable<T>?> AddRange(IEnumerable<T> entities);

    public Task<int> CountAsync();

    public Task<int> CountAsyncWhere(Expression<Func<T, bool>> Filter);

}


