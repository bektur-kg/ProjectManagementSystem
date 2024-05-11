using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Application.Features.Users;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Projects.GetCurrentUserProjects;

public class GetCurrentUserProjectsQueryHandler
    (
        IUserRepository userRepository,
        IProjectRepository projectRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : IQueryHandler<GetCurrentUserProjectsQuery, DataResult<List<ProjectResponse>>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<DataResult<List<ProjectResponse>>> Handle(GetCurrentUserProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var foundUser = await _userRepository.GetByIdAsync(currentUserId);
        if (foundUser is null) return DataResult<List<ProjectResponse>>.Failure(UserErrors.UserNotFound);

        var userProjects = await _projectRepository.GetCurrentUserProjects(currentUserId);
        var mappedUserProjects = _mapper.Map<List<ProjectResponse>>(userProjects);

        return DataResult<List<ProjectResponse>>.Success(mappedUserProjects); 
    }
}

