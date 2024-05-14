using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Projects;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Assignments.Add;

public class AddAssignmentToProjectCommandHandler
    (
        IAssignmentRepository assignmentRepository,
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<AddAssignmentToProjectCommand, Result>
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(AddAssignmentToProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true);
        if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);

        var executor = project.Employees.Any(employee => employee.Id == request.Data.ExecutorId);
        if (!executor) return Result.Failure(ProjectErrors.EmployeeNotFoundInProject);

        var authorId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var assignmet = _mapper.Map<Assignment>(request.Data);
        assignmet.ProjectId = request.ProjectId;
        assignmet.AuthorId = authorId;

        _assignmentRepository.Add(assignmet);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

