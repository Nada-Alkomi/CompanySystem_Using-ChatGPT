using Compant_System.BLL.Dots;

namespace Compant_System.BLL.Services.WorksOnService;

public interface IWorksOnService
{
    Task<IEnumerable<WorksOnDto>> GetAllAsync();

    Task CreateAsync(CreateWorksOnDto dto);

    Task UpdateAsync(
        int ssn,
        int pNumber,
        UpdateWorksOnDto dto);

    Task DeleteAsync(
        int ssn,
        int pNumber);
}