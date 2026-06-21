using Compant_System.BLL.Dots;
using Compant_System.DAL.Models;
using Compant_System.DAL.Repositories.UnitOfWork;

namespace Compant_System.BLL.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _unitOfWork.Projects.GetAllAsync();

        return projects.Select(p => new ProjectDto
        {
            PNumber = p.PNumber,
            PName = p.PName,
            PLocation = p.PLocation,
            
        });
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);

        if (project == null)
            return null;

        return new ProjectDto
        {
            PNumber = project.PNumber,
            PName = project.PName,
            PLocation = project.PLocation,
            
        };
    }

    public async Task CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            PName = dto.PName,
            PLocation = dto.PLocation,
            DNumber = dto.DNumber
        };

        await _unitOfWork.Projects.AddAsync(project);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        int id,
        UpdateProjectDto dto)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);

        if (project == null)
            return;

        project.PName = dto.PName;
        project.PLocation = dto.PLocation;

        _unitOfWork.Projects.Update(project);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);

        if (project == null)
            return;

        _unitOfWork.Projects.Delete(project);

        await _unitOfWork.SaveChangesAsync();
    }
}