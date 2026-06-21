using Compant_System.DAL.Models;
using Company.DAL.Data;
using Compant_System.DAL.Repositories.GenericRepository;
namespace Compant_System.DAL.Repositories.Department_Repository;

using Microsoft.EntityFrameworkCore;

public class DepartmentRepository
    : GenericRepository<Department>,
        IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Department?> GetDepartmentWithEmployeesAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Employees)
            .FirstOrDefaultAsync(d => d.DNumber == id);
    }

    public async Task<Department?> GetDepartmentWithProjectsAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Projects)
            .FirstOrDefaultAsync(d => d.DNumber == id);
    }
}