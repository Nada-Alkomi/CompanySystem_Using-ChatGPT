using System.Linq.Expressions;

namespace Compant_System.DAL.Repositories.GenericRepository;


public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(object id);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate);

    Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate);
}