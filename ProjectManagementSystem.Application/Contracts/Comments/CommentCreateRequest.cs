﻿namespace ProjectManagementSystem.Application.Contracts.Comments;

public record CommentCreateRequest
{
    public required string Content { get; set; }
}

