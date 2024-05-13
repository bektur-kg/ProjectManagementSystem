using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Users;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Projects.AddEmployee;

public class AddEmployeeToProjectComandHandler
    (
        IProjectRepository projectRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<AddEmployeeToProjectComand, Result>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(AddEmployeeToProjectComand request, CancellationToken cancellationToken)
    {
        var employeeToAdd = await _userRepository.GetByIdAsync(request.EmployeeId);
        if (employeeToAdd is null) return Result.Failure(UserErrors.UserNotFound);
        if (employeeToAdd.Role == UserRole.Leader) return Result.Failure(ProjectErrors.CannotAddLeaderAsEmployee);

        var project = await _projectRepository.GetProjectByIdWithIncludeAndTrackingAsync(request.ProjectId, includeEmployees: true);
        if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);
        if (project.Employees.Any(employee => employee.Id == employeeToAdd.Id)) return Result.Failure(ProjectErrors.EmployeeIsAlreadyInProject);

        project.Employees.Add(employeeToAdd);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

