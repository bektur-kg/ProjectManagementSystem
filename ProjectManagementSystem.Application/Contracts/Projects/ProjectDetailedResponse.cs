using ProjectManagementSystem.Application.Contracts.Users;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Contracts.Projects;

public record ProjectDetailedResponse
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string CustomerCompanyTitle { get; set; }
    public required string ExecutorCompanyTitle { get; set; }
    public List<UserResponse> Employees { get; set; } = [];
    public UserResponse? Leader { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public ProjectPriority ProjectPriority { get; set; }
}

