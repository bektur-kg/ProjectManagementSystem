using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Constants;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Application.Features.Assignments.Add;
using ProjectManagementSystem.Application.Features.Assignments.Delete;
using ProjectManagementSystem.Application.Features.Assignments.GetById;
using ProjectManagementSystem.Application.Features.Assignments.GetByProjectId;
using ProjectManagementSystem.Application.Features.Assignments.PartialUpdate;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("api")]
public class AssignmentsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [Authorize]
    [HttpGet("projects/{id}/assignments")]
    public async Task<ActionResult<DataResult<List<AssignmentResponse>>>> GetProjectAssignemnts(long id)
    {
        var query = new GetProjectAssignmentsQuery(id);

        var response = await _sender.Send(query);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpPost("projects/{id}/assignments")]
    public async Task<ActionResult<Result>> AddAssignmentToProject(long id, AddAssignmentRequest dto)
    {
        var command = new AddAssignmentToProjectCommand(id, dto);

        var response = await _sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpDelete("projects/assignments/{id}")]
    public async Task<ActionResult<Result>> DeleteAssignment(long id)
    {
        var command = new DeleteAssignmentCommand(id);

        var response = await _sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpPatch("projects/{projectId}/assignments/{assignmentId}")]
    public async Task<ActionResult<Result>> PartialUpdate(long projectId, long assignmentId, PartialUpdateAssignmentRequest dto)
    {
        var command = new PartialUpdateAssignmentCommand(assignmentId, projectId, dto);

        var response = await _sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize]
    [HttpGet("projects/{projectId}/assignments/{assignmentId}")]
    public async Task<ActionResult<DataResult<AssignmentDetailedResponse>>> GetAssignmentById(long projectId, long assignmentId)
    {
        var query = new GetAssignmentByIdQuery(projectId, assignmentId);

        var response = await _sender.Send(query);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
    }
}
