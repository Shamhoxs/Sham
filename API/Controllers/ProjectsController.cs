using Core.DTOs.Projects;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    // GET: api/projects
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectRepository.GetAllAsync();

        return Ok(projects);
    }

    // GET: api/projects/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project == null)
            return NotFound(new { message = "Project not found." });

        return Ok(project);
    }

    // POST: api/projects
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        var project = new Project
        {
            Title = dto.Title,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            GithubUrl = dto.GithubUrl,
            LiveUrl = dto.LiveUrl,
            CreatedAt = DateTime.UtcNow
        };

        await _projectRepository.AddAsync(project);

        return CreatedAtAction(
            nameof(GetById),
            new { id = project.Id },
            project);
    }

    // PUT: api/projects/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProjectDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project == null)
            return NotFound(new { message = "Project not found." });

        project.Title = dto.Title;
        project.Description = dto.Description;
        project.ImageUrl = dto.ImageUrl;
        project.GithubUrl = dto.GithubUrl;
        project.LiveUrl = dto.LiveUrl;

        await _projectRepository.UpdateAsync(project);

        return Ok(project);
    }

    // DELETE: api/projects/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project == null)
            return NotFound(new { message = "Project not found." });

        await _projectRepository.DeleteAsync(project);

        return NoContent();
    }
}