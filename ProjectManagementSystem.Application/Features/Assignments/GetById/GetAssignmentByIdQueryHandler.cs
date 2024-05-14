using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Assignments.GetById;

public class GetAssignmentByIdQueryHandler
    (
        IAssignmentRepository assignmentRepository,
        IProjectRepository projectRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : IQueryHandler<GetAssignmentByIdQuery, DataResult<AssignmentDetailedResponse>>
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<DataResult<AssignmentDetailedResponse>> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true);

        if (project is null) return DataResult<AssignmentDetailedResponse>.Failure(ProjectErrors.ProjectNotFound);

        var assignment = await _assignmentRepository.GetAssignmentByIdWithIncludeAsync(request.AssignmentId, includeAuthor: true,
            includeComments: true, includeExecutor: true);

        if (assignment is null) return DataResult<AssignmentDetailedResponse>.Failure(AssignmentErrors.AssignmentNotFound);

        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var doesEmployeeExistInProject = project.Employees.Any(employee => employee.Id == userId);
        var userRole = _httpContext.User.FindFirstValue(ClaimTypes.Role);

        if (!doesEmployeeExistInProject && userRole != UserRole.Leader.ToString()) 
            return DataResult<AssignmentDetailedResponse>.Failure(ProjectErrors.EmployeeNotFoundInProject);

        var mappedAssignment = _mapper.Map<AssignmentDetailedResponse>(assignment);

        return DataResult<AssignmentDetailedResponse>.Success(mappedAssignment);
    }
}

