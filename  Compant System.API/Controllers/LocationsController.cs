using Compant_System.BLL.Dots;
using Compant_System.BLL.Services.LocationService;
using Microsoft.AspNetCore.Mvc;

namespace Compant_System.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _service;

    public LocationsController(ILocationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _service.GetAllAsync();

        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var location = await _service.GetByIdAsync(id);

        if (location == null)
            return NotFound();

        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationDto dto)
    {
        await _service.CreateAsync(dto);

        return Ok("Location Created Successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateLocationDto dto)
    {
        await _service.UpdateAsync(id, dto);

        return Ok("Location Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok("Location Deleted Successfully");
    }
}