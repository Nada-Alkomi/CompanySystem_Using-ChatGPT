using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.LocationService;

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;

    public LocationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<LocationDto>> GetAllAsync()
    {
        var locations =
            await _unitOfWork.Locations.GetAllAsync();

        return locations.Select(l => new LocationDto
        {
            Id = l.Id,
            LocationName = l.LocationName,
            DNumber = l.DNumber
        });
    }

    public async Task<LocationDto?> GetByIdAsync(int id)
    {
        var location =
            await _unitOfWork.Locations.GetByIdAsync(id);

        if (location == null)
            return null;

        return new LocationDto
        {
            Id = location.Id,
            LocationName = location.LocationName,
            DNumber = location.DNumber
        };
    }

    public async Task CreateAsync(CreateLocationDto dto)
    {
        var location = new Location
        {
            LocationName = dto.LocationName,
            DNumber = dto.DNumber
        };

        await _unitOfWork.Locations.AddAsync(location);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        int id,
        UpdateLocationDto dto)
    {
        var location =
            await _unitOfWork.Locations.GetByIdAsync(id);

        if (location == null)
            return;

        location.LocationName = dto.LocationName;
        location.DNumber = dto.DNumber;

        _unitOfWork.Locations.Update(location);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var location =
            await _unitOfWork.Locations.GetByIdAsync(id);

        if (location == null)
            return;

        _unitOfWork.Locations.Delete(location);

        await _unitOfWork.SaveChangesAsync();
    }
}