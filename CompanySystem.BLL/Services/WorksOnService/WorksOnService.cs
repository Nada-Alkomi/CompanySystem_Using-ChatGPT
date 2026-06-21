using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.WorksOnService;

public class WorksOnService : IWorksOnService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorksOnService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorksOnDto>> GetAllAsync()
    {
        var worksOn =
            await _unitOfWork.WorksOns.GetAllAsync();

        return worksOn.Select(w => new WorksOnDto
        {
            SSN = w.SSN,
            PNumber = w.PNumber,
            Hours = w.Hours
        });
    }

    public async Task CreateAsync(CreateWorksOnDto dto)
    {
        var work = new Works_On
        {
            SSN = dto.SSN,
            PNumber = dto.PNumber,
            Hours = dto.Hours
        };

        await _unitOfWork.WorksOns.AddAsync(work);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        int ssn,
        int pNumber,
        UpdateWorksOnDto dto)
    {
        var work = (await _unitOfWork.WorksOns.GetAllAsync())
            .FirstOrDefault(x =>
                x.SSN == ssn &&
                x.PNumber == pNumber);

        if (work == null)
            return;

        work.Hours = dto.Hours;

        _unitOfWork.WorksOns.Update(work);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        int ssn,
        int pNumber)
    {
        var work = (await _unitOfWork.WorksOns.GetAllAsync())
            .FirstOrDefault(x =>
                x.SSN == ssn &&
                x.PNumber == pNumber);

        if (work == null)
            return;

        _unitOfWork.WorksOns.Delete(work);

        await _unitOfWork.SaveChangesAsync();
    }
}