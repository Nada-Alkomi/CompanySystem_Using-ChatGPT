using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.DependentService;

public class DependentService : IDependentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DependentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DependentDto>> GetAllAsync()
    {
        var dependents =
            await _unitOfWork.Dependents.GetAllAsync();

        return dependents.Select(d => new DependentDto
        {
            Id = d.Id,
            DependentName = d.DependentName,
            Gender = d.Gender,
            BirthDate = d.BirthDate,
            Relationship = d.Relationship,
            SSN = d.SSN
        });
    }

    public async Task<DependentDto?> GetByIdAsync(int id)
    {
        var dependent =
            await _unitOfWork.Dependents.GetByIdAsync(id);

        if (dependent == null)
            return null;

        return new DependentDto
        {
            Id = dependent.Id,
            DependentName = dependent.DependentName,
            Gender = dependent.Gender,
            BirthDate = dependent.BirthDate,
            Relationship = dependent.Relationship,
            SSN = dependent.SSN
        };
    }

    public async Task CreateAsync(CreateDependentDto dto)
    {
        var dependent = new Dependent
        {
            DependentName = dto.DependentName,
            Gender = dto.Gender,
            BirthDate = dto.BirthDate,
            Relationship = dto.Relationship,
            SSN = dto.SSN
        };

        await _unitOfWork.Dependents.AddAsync(dependent);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        int id,
        UpdateDependentDto dto)
    {
        var dependent =
            await _unitOfWork.Dependents.GetByIdAsync(id);

        if (dependent == null)
            return;

        dependent.DependentName = dto.DependentName;
        dependent.Gender = dto.Gender;
        dependent.BirthDate = dto.BirthDate;
        dependent.Relationship = dto.Relationship;

        _unitOfWork.Dependents.Update(dependent);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dependent =
            await _unitOfWork.Dependents.GetByIdAsync(id);

        if (dependent == null)
            return;

        _unitOfWork.Dependents.Delete(dependent);

        await _unitOfWork.SaveChangesAsync();
    }
}