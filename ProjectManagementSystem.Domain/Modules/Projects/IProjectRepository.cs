using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Domain.Modules.Projects;

public interface IProjectRepository : IRepository<Project>
{
    Task<List<Project>> GetCurrentUserProjects(long currentUserId);
    Task<Project?> GetProjectByIdWithIncludeAsync(long id, bool includeEmployees = false, bool includeLeader = false, bool includeAssignments = false);
    Task<Project?> GetProjectByIdWithIncludeAndTrackingAsync(long id, bool includeEmployees = false, bool includeLeader = false, bool includeAssignments = false);
}