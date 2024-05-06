using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects;

public abstract class ProjectErrors
{
    public Error ProjectNotFound = new("Project.NotFound", "Project is not found");
}

