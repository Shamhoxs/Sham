using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<IReadOnlyList<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
}