using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.GenericRepository;

namespace Compant_System.DAL.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Employee> Employees { get; }

    IGenericRepository<Department> Departments { get; }

    IGenericRepository<Project> Projects { get; }

    IGenericRepository<Dependent> Dependents { get; }

    IGenericRepository<Location> Locations { get; }

    IGenericRepository<Works_On> WorksOns { get; }

    Task<int> SaveChangesAsync();
}