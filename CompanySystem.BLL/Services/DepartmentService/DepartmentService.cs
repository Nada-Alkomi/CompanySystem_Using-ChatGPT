using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.DepartmentService;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();

        return departments.Select(d => new DepartmentDto
        {
            DNumber = d.DNumber,
            DName = d.DName
        });
    }

    public async Task<DepartmentDto?> GetByIdAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null)
            return null;

        return new DepartmentDto
        {
            DNumber = department.DNumber,
            DName = department.DName
        };
    }

    public async Task CreateAsync(CreateDepartmentDto dto)
    {
        var department = new Department
        {
            DName = dto.DName,
            MgrSSN = dto.MgrSSN
        };

        await _unitOfWork.Departments.AddAsync(department);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UpdateDepartmentDto dto)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null) return;

        department.DName = dto.DName;
        department.MgrSSN = dto.MgrSSN;

        _unitOfWork.Departments.Update(department);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null) return;

        _unitOfWork.Departments.Delete(department);
        await _unitOfWork.SaveChangesAsync();
    }
}