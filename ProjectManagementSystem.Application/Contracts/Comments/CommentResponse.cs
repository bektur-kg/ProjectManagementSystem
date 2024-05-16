using ProjectManagementSystem.Application.Contracts.Users;

namespace ProjectManagementSystem.Application.Contracts.Comments;

public record CommentResponse
{
    public long Id { get; set; }
    public UserResponse? Author { get; set; }
    public required string Content { get; set; }
}

