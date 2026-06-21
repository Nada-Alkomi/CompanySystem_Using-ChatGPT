using Compant_System.BLL.Dots;
using Compant_System.BLL.Services.WorksOnService;
using Microsoft.AspNetCore.Mvc;

namespace Compant_System.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorksOnController : ControllerBase
{
    private readonly IWorksOnService _service;

    public WorksOnController(IWorksOnService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateWorksOnDto dto)
    {
        await _service.CreateAsync(dto);

        return Ok("Created Successfully");
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        int ssn,
        int pNumber,
        UpdateWorksOnDto dto)
    {
        await _service.UpdateAsync(
            ssn,
            pNumber,
            dto);

        return Ok("Updated Successfully");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        int ssn,
        int pNumber)
    {
        await _service.DeleteAsync(
            ssn,
            pNumber);

        return Ok("Deleted Successfully");
    }
}