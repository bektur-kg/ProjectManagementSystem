using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Domain.Modules.Comments;
public interface ICommentRepository : IRepository<Comment>
{
    Task<List<Comment>> GetByAssignmentIdAsync(long assignmentId);
    Task<Comment?> GetByIdWithIncludeAsync(long commentId, bool includeAuthor = false, bool includeAssignment = false);
    Task<List<Comment>> GetByAssignmentIdWithIncludeAsync(long assignmentId, bool includeAuthor = false, bool includeAssignment = false);
}
