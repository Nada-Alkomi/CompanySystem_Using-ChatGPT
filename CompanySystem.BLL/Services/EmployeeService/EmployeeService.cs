using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetEmployeeDto>> GetAllAsync()
    {
        var employees = await _unitOfWork.Employees.GetAllAsync();

        return employees.Select(e => new GetEmployeeDto
        {
            SSN = e.SSN,
            FullName = $"{e.FName} {e.LName}",
            Salary = e.Salary
        });
    }

    public async Task<GetEmployeeDto?> GetByIdAsync(int id)
    {
        var employee =
            await _unitOfWork.Employees.GetByIdAsync(id);

        if (employee == null)
            return null;

        return new GetEmployeeDto
        {
            SSN = employee.SSN,
            FullName = $"{employee.FName} {employee.LName}",
            Salary = employee.Salary
        };
    }

    public async Task CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FName = dto.FName,
            LName = dto.LName,
            BDate = dto.BDate,
            Address = dto.Address,
            Gender = dto.Gender,
            Salary = dto.Salary,
            Dno = dto.Dno,
            SuperSSN = dto.SuperSSN
        };

        await _unitOfWork.Employees.AddAsync(employee);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
    {
        var employee =
            await _unitOfWork.Employees.GetByIdAsync(id);

        if (employee == null)
            return;

        employee.FName = dto.FName;
        employee.LName = dto.LName;
        employee.Address = dto.Address;
        employee.Salary = dto.Salary;
        employee.Dno = dto.Dno;

        _unitOfWork.Employees.Update(employee);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee =
            await _unitOfWork.Employees.GetByIdAsync(id);

        if (employee == null)
            return;

        _unitOfWork.Employees.Delete(employee);

        await _unitOfWork.SaveChangesAsync();
    }
}