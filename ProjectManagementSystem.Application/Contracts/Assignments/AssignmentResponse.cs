﻿using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Application.Contracts.Users;
using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Application.Contracts.Assignments;

public record AssignmentResponse
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public UserResponse? Author { get; set; }
    public UserResponse? Executor { get; set; }
    public List<CommentResponse> Comments { get; set; } = [];
    public AssignmentPriority Priority { get; set; }
    public AssignmentStatus Status { get; set; }
}