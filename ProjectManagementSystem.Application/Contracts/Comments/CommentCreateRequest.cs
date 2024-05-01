using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Contracts.Comments;

public record CommentCreateRequest
{
    public long? AuthorId { get; set; }
    public User? Author { get; set; }
    public long? AssignmentId { get; set; }
    public Assignment? Assignment { get; set; }
    public required string Content { get; set; }
}

