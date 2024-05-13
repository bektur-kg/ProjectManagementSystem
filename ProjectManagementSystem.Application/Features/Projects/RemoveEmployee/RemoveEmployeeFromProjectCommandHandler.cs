using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Users;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Projects.RemoveEmployee;

public class RemoveEmployeeFromProjectCommandHandler
    (
        IProjectRepository projectRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<RemoveEmployeeFromProjectCommand, Result>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RemoveEmployeeFromProjectCommand request, CancellationToken cancellationToken)
    {
        //var employeeToRemove = await _userRepository.GetByIdAsync(request.EmployeeId);
        //if (employeeToRemove is null) return Result.Failure(UserErrors.UserNotFound);

        //var project = await _projectRepository.GetProjectByIdWithIncludeAndTrackingAsync(request.ProjectId, includeEmployees: true, includeLeader: true);
        //if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);
        //if (!project.Employees.Any(employee => employee.Id == employeeToRemove.Id)) 
        //    return Result.Failure(ProjectErrors.EmployeeNotFoundInProject);

        //project.Employees.Remove(employeeToRemove);
        //if (project.Leader?.Id == employeeToRemove.Id) 
        //    project.Leader = null;

        //await _unitOfWork.SaveChangesAsync();

        //return Result.Success();

        var project = await _projectRepository.GetProjectByIdWithIncludeAndTrackingAsync
        (
            request.ProjectId,
            includeEmployees: true,
            includeLeader: true
        );

        if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);
        if (!project.Employees.Any(employee => employee.Id == request.EmployeeId))
            return Result.Failure(ProjectErrors.EmployeeNotFoundInProject);

        var employeeToRemove = project.Employees.First(employee => employee.Id == request.EmployeeId);
        project.Employees.Remove(employeeToRemove);

        if (project.Leader?.Id == employeeToRemove.Id) project.Leader = null;

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

