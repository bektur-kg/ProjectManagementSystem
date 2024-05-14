using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Assignments;

public class AssignmentRepository(AppDbContext dbContext) : Repository<Assignment>(dbContext), IAssignmentRepository
{
    public Task<Assignment?> GetAssignmentByIdWithIncludeAndTrackingAsync(long assignmentId, bool includeAuthor = false, bool includeExecutor = false, bool includeComments = false)
    {
        var query = DbContext.Assignments.AsQueryable();

        if (includeAuthor) query = query.Include(assignment => assignment.Author);
        if (includeExecutor) query = query.Include(assignment => assignment.Executor);
        if (includeComments) query = query.Include(assignment => assignment.Comments);

        return query.FirstOrDefaultAsync(assignment => assignment.Id == assignmentId);
    }

    public Task<Assignment?> GetAssignmentByIdWithIncludeAsync(long assignmentId, bool includeAuthor = false, bool includeExecutor = false,
        bool includeComments = false)
    {
        var query = DbContext.Assignments.AsNoTracking();

        if (includeAuthor) query = query.Include(assignment => assignment.Author);
        if (includeExecutor) query = query.Include(assignment => assignment.Executor);
        if (includeComments) query = query.Include(assignment => assignment.Comments);

        return query.FirstOrDefaultAsync(assignment => assignment.Id == assignmentId);
    }

    public Task<List<Assignment>> GetAssignmentsByProjectIdAsync(long projectId)
    {
        return DbContext.Assignments
            .AsNoTracking()
            .Where(assignment => assignment.ProjectId == projectId)
            .ToListAsync();
    }

    public Task<List<Assignment>> GetAssignmentsByProjectIdWithIncludeAsync(long projectId, bool includeAuthor = false,
        bool includeExecutor = false, bool includeComments = false)
    {
        var query = DbContext.Assignments.AsNoTracking();

        if (includeAuthor) query = query.Include(assignment => assignment.Author);
        if (includeExecutor) query = query.Include(assignment => assignment.Executor);
        if (includeComments) query = query.Include(assignment => assignment.Comments);

        return query.ToListAsync();
    }
}

