using Compant_System.DAL.Models;

namespace Compant_System.DAL.Repositories.WorksOn_Repository;

public interface IWorksOnRepository
{
    Task<Works_On?> GetByIdAsync(int ssn, int pNumber);

    Task<IEnumerable<Works_On>> GetEmployeeProjectsAsync(int ssn);

    Task<IEnumerable<Works_On>> GetProjectEmployeesAsync(int pNumber);
}