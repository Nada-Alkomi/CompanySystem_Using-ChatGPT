using Compant_System.DAL.Models;
using Company.DAL.Data;

namespace Compant_System.DAL.Repositories.WorksOn_Repository;
using Compant_System.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

public class WorksOnRepository
    : GenericRepository<Works_On>,
        IWorksOnRepository
{
    public WorksOnRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Works_On?> GetByIdAsync(
        int ssn,
        int pNumber)
    {
        return await _context.WorksOns
            .FirstOrDefaultAsync(x =>
                x.SSN == ssn &&
                x.PNumber == pNumber);
    }

    public async Task<IEnumerable<Works_On>> GetEmployeeProjectsAsync(int ssn)
    {
        return await _context.WorksOns
            .Include(x => x.Project)
            .Where(x => x.SSN == ssn)
            .ToListAsync();
    }

    public async Task<IEnumerable<Works_On>> GetProjectEmployeesAsync(int pNumber)
    {
        return await _context.WorksOns
            .Include(x => x.Employee)
            .Where(x => x.PNumber == pNumber)
            .ToListAsync();
    }
}