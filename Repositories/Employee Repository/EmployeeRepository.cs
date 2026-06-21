using Compant_System.DAL.Models;
using Company.DAL.Data;

namespace Compant_System.DAL.Repositories.Employee_Repository;
using Compant_System.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository
    : GenericRepository<Employee>,
        IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Employee?> GetEmployeeWithDepartmentAsync(int ssn)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.SSN == ssn);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
    {
        return await _context.Employees
            .Where(e => e.Dno == departmentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployeesWithSupervisorAsync()
    {
        return await _context.Employees
            .Include(e => e.Supervisor)
            .ToListAsync();
    }
}