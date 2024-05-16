using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Assignments;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Comments.Create;

public class CreateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IProjectRepository projectRepository,
        IAssignmentRepository assignmentRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateCommentCommand, Result>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true);

        if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);

        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userRole = _httpContext.User.FindFirstValue(ClaimTypes.Role);
        var doesUserExistInProject = project.Employees.Any(employee => employee.Id == userId);

        if (!doesUserExistInProject && userRole != UserRole.Leader.ToString()) return Result.Failure(ProjectErrors.EmployeeNotFoundInProject);

        var assignment = await _assignmentRepository.GetByIdAsync(request.AssignmentId);

        if (assignment is null) return Result.Failure(AssignmentErrors.AssignmentNotFound);

        var newComment = new Comment 
        {
            Content = request.Data.Content,
            AuthorId = userId,
            AssignmentId = assignment.Id,
        };

        _commentRepository.Add(newComment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

