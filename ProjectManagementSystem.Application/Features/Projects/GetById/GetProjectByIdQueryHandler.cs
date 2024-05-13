using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Projects.GetById;

public class GetProjectByIdQueryHandler
    (
        IProjectRepository projectRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    )
    : IQueryHandler<GetProjectByIdQuery, DataResult<ProjectDetailedResponse>>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<DataResult<ProjectDetailedResponse>> Handle(GetProjectByIdQuery request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeLeader: true, 
            includeEmployees: true);
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var currentUserRole = _httpContext.User.FindFirstValue(ClaimTypes.Role);

        if (project is null) return DataResult<ProjectDetailedResponse>.Failure(ProjectErrors.ProjectNotFound);
        if
        (
            (currentUserRole == UserRole.ProjectManager.ToString() ||
            currentUserRole == UserRole.Employee.ToString()) &&
            !project.Employees.Any(employee => employee.Id == currentUserId) 
        )
        {
            return DataResult<ProjectDetailedResponse>.Failure(ProjectErrors.NotAccessible);
        }

        var mappedProject = _mapper.Map<ProjectDetailedResponse>(project);

        return DataResult<ProjectDetailedResponse>.Success(mappedProject);
    }
}

