using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.GenericRepository;
using Compant_System.DAL.Repositories.UnitOfWork;
using Company.DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IGenericRepository<Employee> Employees { get; }

    public IGenericRepository<Department> Departments { get; }

    public IGenericRepository<Project> Projects { get; }

    public IGenericRepository<Dependent> Dependents { get; }

    public IGenericRepository<Location> Locations { get; }

    public IGenericRepository<Works_On> WorksOns { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Employees =
            new GenericRepository<Employee>(context);

        Departments =
            new GenericRepository<Department>(context);

        Projects =
            new GenericRepository<Project>(context);

        Dependents =
            new GenericRepository<Dependent>(context);

        Locations =
            new GenericRepository<Location>(context);

        WorksOns =
            new GenericRepository<Works_On>(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}