using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Comments.GetAll;

public class GetAllCommentsByAssignmentIdHandler
    (
        ICommentRepository commentRepository,
        IProjectRepository projectRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : IQueryHandler<GetAllCommentsByAssignmentId, DataResult<List<CommentResponse>>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<DataResult<List<CommentResponse>>> Handle(GetAllCommentsByAssignmentId request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true);

        if (project is null) return DataResult<List<CommentResponse>>.Failure(ProjectErrors.ProjectNotFound);

        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userRole = _httpContext.User.FindFirstValue(ClaimTypes.Role);
        var doesEmployeeIncludeInProject = project.Employees.Any(employee => employee.Id == userId);

        if(!doesEmployeeIncludeInProject && userRole != UserRole.Leader.ToString())
            return DataResult<List<CommentResponse>>.Failure(ProjectErrors.EmployeeNotFoundInProject);

        var comments = await _commentRepository.GetByAssignmentIdWithIncludeAsync(request.AssignmentId, includeAuthor: true);
        var mappedComments = _mapper.Map<List<CommentResponse>>(comments);

        return DataResult<List<CommentResponse>>.Success(mappedComments);
    }
}

