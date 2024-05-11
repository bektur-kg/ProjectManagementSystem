using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Contracts.Projects;

public record CreateProjectRequest
{
    public required string Title { get; set; }
    public required string CustomerCompanyTitle { get; set; }
    public required string ExecutorCompanyTitle { get; set; }
    public ProjectPriority ProjectPriority { get; set; }
}

