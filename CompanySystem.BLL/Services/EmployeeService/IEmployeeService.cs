using Compant_System.BLL.Dots;

namespace Compant_System.BLL.Services.EmployeeService;

public interface IEmployeeService
{
    Task<IEnumerable<GetEmployeeDto>> GetAllAsync();

    Task<GetEmployeeDto?> GetByIdAsync(int id);

    Task CreateAsync(CreateEmployeeDto dto);

    Task UpdateAsync(int id,
        UpdateEmployeeDto dto);

    Task DeleteAsync(int id);
}