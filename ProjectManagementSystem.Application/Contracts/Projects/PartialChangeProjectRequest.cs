using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Contracts.Projects;

public record PartialChangeProjectRequest
{
    public string? Title { get; set; }
    public string? CustomerCompanyTitle { get; set; }
    public string? ExecutorCompanyTitle { get; set; }
    public long? LeaderId { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public ProjectPriority? ProjectPriority { get; set; }
}

