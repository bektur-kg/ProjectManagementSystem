using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Contracts.Projects;

public record ProjectResponse
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string CustomerCompanyTitle { get; set; }
    public required string ExecutorCompanyTitle { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public ProjectPriority ProjectPriority { get; set; }
}

