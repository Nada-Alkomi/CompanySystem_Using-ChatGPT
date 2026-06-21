using Compant_System.DAL.Models;

namespace Compant_System.DAL.Repositories.Project_Repository;


public interface IProjectRepository
{
    Task<Project?> GetProjectWithEmployeesAsync(int id);

    Task<IEnumerable<Project>> GetProjectsByDepartmentAsync(int departmentId);
}