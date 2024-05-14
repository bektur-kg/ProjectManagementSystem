using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Contracts.Comments;

public record CommentResponse
{
    public User? Author { get; set; }
    public required string Content { get; set; }
}

