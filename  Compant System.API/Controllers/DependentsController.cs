using Compant_System.BLL.Dots;
using Compant_System.BLL.Services.DependentService;
using Microsoft.AspNetCore.Mvc;

namespace Compant_System.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly IDependentService _service;

    public DependentsController(IDependentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDependentDto dto)
    {
        await _service.CreateAsync(dto);

        return Ok("Dependent Created Successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateDependentDto dto)
    {
        await _service.UpdateAsync(id, dto);

        return Ok("Dependent Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok("Dependent Deleted Successfully");
    }
}