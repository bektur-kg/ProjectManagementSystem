namespace ProjectManagementSystem.Application.Contracts.Comments;

public record CommentCreateRequest
{
    public long? AssignmentId { get; set; }
    public required string Content { get; set; }
}

