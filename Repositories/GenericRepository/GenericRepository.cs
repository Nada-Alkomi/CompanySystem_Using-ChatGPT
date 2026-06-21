using System.Linq.Expressions;
using Company.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Compant_System.DAL.Repositories.GenericRepository;
namespace Compant_System.DAL.Repositories.GenericRepository;


public class GenericRepository<T>
    : IGenericRepository<T>
    where T : class
{
    protected readonly AppDbContext _context;

    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await _dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await _dbSet
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }
}