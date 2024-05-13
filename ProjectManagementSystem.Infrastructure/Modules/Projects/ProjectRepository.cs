using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Projects;

public class ProjectRepository(AppDbContext dbContext) : Repository<Project>(dbContext), IProjectRepository
{
    public Task<List<Project>> GetCurrentUserProjects(long currentUserId)
    {
        return DbContext.Projects
            .Where(project => project.Employees.Any(employee => employee.Id == currentUserId))
            .ToListAsync();
    }

    public Task<Project?> GetProjectByIdWithIncludeAndTrackingAsync(long id, bool includeEmployees = false, bool includeLeader = false, bool includeAssignments = false)
    {
        var query = DbContext.Projects.AsQueryable();

        if (includeEmployees) query = query.Include(project => project.Employees);
        if (includeLeader) query = query.Include(project => project.Leader);
        if (includeAssignments) query = query.Include(project => project.Assignments);

        return query.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<Project?> GetProjectByIdWithIncludeAsync(long id, bool includeEmployees = false, bool includeLeader = false, bool includeAssignments = false)
    {
        var query = DbContext.Projects.AsNoTracking();

        if (includeEmployees) query = query.Include(project => project.Employees);
        if (includeLeader) query = query.Include(project => project.Leader);
        if (includeAssignments) query = query.Include(project => project.Assignments);

        return query.FirstOrDefaultAsync(entity => entity.Id == id);
    }
}
