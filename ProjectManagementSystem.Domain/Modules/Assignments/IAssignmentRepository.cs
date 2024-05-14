using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Domain.Modules.Assignments;

public interface IAssignmentRepository : IRepository<Assignment>
{
    Task<List<Assignment>> GetAssignmentsByProjectIdAsync(long projectId);
    Task<List<Assignment>> GetAssignmentsByProjectIdWithIncludeAsync(long projectId, bool includeAuthor = false,
        bool includeExecutor = false, bool includeComments = false);
    Task<Assignment?> GetAssignmentByIdWithIncludeAsync(long assignmentId, bool includeAuthor = false,
        bool includeExecutor = false, bool includeComments = false);
    Task<Assignment?> GetAssignmentByIdWithIncludeAndTrackingAsync(long assignmentId, bool includeAuthor = false,
        bool includeExecutor = false, bool includeComments = false);
}