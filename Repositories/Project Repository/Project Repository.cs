using Compant_System.DAL.Models;
using Company.DAL.Data;

namespace Compant_System.DAL.Repositories.Project_Repository;
using Compant_System.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

public class ProjectRepository
    : GenericRepository<Project>,
        IProjectRepository
{
    public ProjectRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Project?> GetProjectWithEmployeesAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.WorksOns)
            .ThenInclude(w => w.Employee)
            .FirstOrDefaultAsync(p => p.PNumber == id);
    }

    public async Task<IEnumerable<Project>> GetProjectsByDepartmentAsync(int departmentId)
    {
        return await _context.Projects
            .Where(p => p.DNumber == departmentId)
            .ToListAsync();
    }
}