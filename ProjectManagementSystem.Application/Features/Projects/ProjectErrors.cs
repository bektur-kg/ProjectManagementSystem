using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects;

public static class ProjectErrors
{
    public static Error ProjectNotFound = new("Project.NotFound", "Project is not found");
}

