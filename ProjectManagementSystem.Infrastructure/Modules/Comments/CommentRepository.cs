using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository
{
    public Task<List<Comment>> GetByAssignmentIdAsync(long assignmentId)
    {
        return DbContext.Comments
            .AsNoTracking()
            .Where(comment => comment.AssignmentId == assignmentId)
            .ToListAsync();
    }

    public Task<List<Comment>> GetByAssignmentIdWithIncludeAsync(long assignmentId, bool includeAuthor = false, bool includeAssignment = false)
    {
        var query = DbContext.Comments.AsNoTracking();

        if (includeAuthor) query = query.Include(comment => comment.Author);
        if (includeAssignment) query = query.Include(comment => comment.Assignment);

        return query.ToListAsync();
    }

    public Task<Comment?> GetByIdWithIncludeAsync(long commentId, bool includeAuthor = false, bool includeAssignment = false)
    {
        var query = DbContext.Comments.AsNoTracking();

        if (includeAuthor) query = query.Include(comment => comment.Author);
        if (includeAssignment) query = query.Include(comment => comment.Assignment);

        return query.FirstOrDefaultAsync(comment => comment.Id == commentId);
    }
}

