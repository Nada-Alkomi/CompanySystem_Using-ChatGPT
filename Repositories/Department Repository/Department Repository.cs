using Compant_System.DAL.Models;

namespace Compant_System.DAL.Repositories.Department_Repository;

public interface IDepartmentRepository
{
    Task<Department?> GetDepartmentWithEmployeesAsync(int id);

    Task<Department?> GetDepartmentWithProjectsAsync(int id);
}