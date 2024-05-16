namespace ProjectManagementSystem.Application.Contracts.Comments;

public record UpdateCommentRequest
{
    public required string Content { get; set; }
}

