using Compant_System.DAL.Models;

namespace Compant_System.DAL.Repositories.Employee_Repository;
public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeWithDepartmentAsync(int ssn);

    Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);

    Task<IEnumerable<Employee>> GetEmployeesWithSupervisorAsync();
}