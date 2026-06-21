using Compant_System.BLL.Dots;

namespace Compant_System.BLL.Services.DependentService;

public interface IDependentService
{
    Task<IEnumerable<DependentDto>> GetAllAsync();

    Task<DependentDto?> GetByIdAsync(int id);

    Task CreateAsync(CreateDependentDto dto);

    Task UpdateAsync(int id, UpdateDependentDto dto);

    Task DeleteAsync(int id);
}