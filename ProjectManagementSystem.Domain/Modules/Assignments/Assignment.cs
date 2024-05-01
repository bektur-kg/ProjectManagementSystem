using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Domain.Modules.Assignments;

public class Assignment : Entity
{
    public required string Title { get; set; }
    public long AssignmentAuthorId { get; set; }
    public User? AssignmentAuthor { get; set; }
    public long ExecutorId { get; set; }
    public User? Executor { get; set; }
    public List<Comment>? Comments { get; set; }
    public AssignmentPriority AssignmentPriority { get; set; }

}

