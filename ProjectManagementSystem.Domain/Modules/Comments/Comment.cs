﻿using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Domain.Modules.Comments;

public class Comment : Entity
{
    public long? AuthorId { get; set; }
    public User? Author { get; set; }
    public long? AssignmentId { get; set; }
    public Assignment? Assignment { get; set; }
    public required string Content { get; set; }
}

