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

namespace ProjectManagementSystem.Application.Features.Assignments.GetByProjectId;

public class GetProjectAssignmentsQueryHandler
    (
        IAssignmentRepository assignmentRepository,
        IHttpContextAccessor httpContextAccessor,
        IProjectRepository projectRepository,
        IMapper mapper
    )
    : IQueryHandler<GetProjectAssignmentsQuery, DataResult<List<AssignmentResponse>>>
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<DataResult<List<AssignmentResponse>>> Handle(GetProjectAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentRepository.GetAssignmentsByProjectIdWithIncludeAsync
        (
            request.ProjectId,
            includeAuthor: true,
            includeComments: true,
            includeExecutor: true
        );
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userRole = _httpContext.User.FindFirstValue(ClaimTypes.Role);
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true);
        var doesEmployeeIncludeInProject = project?.Employees.Any(employee => employee.Id == userId) ?? false;
        
        if(project is null) return DataResult<List<AssignmentResponse>>.Failure(ProjectErrors.ProjectNotFound);
        if (!doesEmployeeIncludeInProject && userRole != UserRole.Leader.ToString()) return DataResult<List<AssignmentResponse>>.Failure(AssignmentErrors.NotAccessible);

        var mappedAssignments = _mapper.Map<List<AssignmentResponse>>(assignments);

        return DataResult<List<AssignmentResponse>>.Success(mappedAssignments);
    }
}

