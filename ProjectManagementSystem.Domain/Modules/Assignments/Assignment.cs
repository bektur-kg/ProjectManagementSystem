using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Domain.Modules.Assignments;

public class Assignment : Entity
{
    public required string Title { get; set; }
    public long? AuthorId { get; set; }
    public User? Author { get; set; }
    public long? ExecutorId { get; set; }
    public User? Executor { get; set; }
    public Project? Project { get; set; }
    public long? ProjectId { get; set; }
    public List<Comment>? Comments { get; set; }
    public AssignmentPriority Priority { get; set; }
    public AssignmentStatus Status { get; set; }

}

