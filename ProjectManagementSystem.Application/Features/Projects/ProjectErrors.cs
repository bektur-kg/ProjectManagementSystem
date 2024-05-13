using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects;

public abstract class ProjectErrors
{
    public static Error ProjectNotFound = new("Project.NotFound", "Project is not found");
    public static Error NotAccessible = new("Project.NotAccessible", "You don't have an access for this project");
    public static Error CannotAddLeaderAsEmployee = new("Project.CannotAddLeaderAsEmployee", "You cannot add Leader as employee for this project");
    public static Error EmployeeIsAlreadyInProject = new("Project.EmployeeIsAlreadyInProject", "This employee is already in this project");
    public static Error EmployeeNotFoundInProject = new("Project.EmployeeNotFoundInProject", "This employee is not found in this project");
}

