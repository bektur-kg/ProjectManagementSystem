using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Domain.Modules.Projects;

public class Project : Entity
{
    public required string Title { get; set; }
    public required string CustomerCompanyTitle { get; set; }
    public required string ExecutorCompanyTitle { get; set; }
    public List<User>? Employees { get; set; }
    public User? Leader { get; set; }
    public long? LeaderId { get; set; }
    public List<Assignment>? Assignments { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public ProjectPriority ProjectPriority { get; set; }
}

