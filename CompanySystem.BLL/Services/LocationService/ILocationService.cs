using Compant_System.BLL.Dots;

namespace Compant_System.BLL.Services.LocationService;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllAsync();

    Task<LocationDto?> GetByIdAsync(int id);

    Task CreateAsync(CreateLocationDto dto);

    Task UpdateAsync(int id, UpdateLocationDto dto);

    Task DeleteAsync(int id);
}