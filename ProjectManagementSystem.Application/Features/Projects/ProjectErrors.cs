using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects;

public abstract class ProjectErrors
{
    public static Error ProjectNotFound = new("Project.NotFound", "Project is not found");
    public static Error NotAccessible = new("Project.NotAccessible", "You don't have an access for this project");
}

