using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Application.Features.Comments.Create;
using ProjectManagementSystem.Application.Features.Comments.Delete;
using ProjectManagementSystem.Application.Features.Comments.GetAll;
using ProjectManagementSystem.Application.Features.Comments.Update;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("api")]
public class CommentsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [Authorize]
    [HttpGet("projects/{projectId}/assignments/{assignmentId}/comments")]
    public async Task<ActionResult<DataResult<CommentResponse>>> GetAssignmentComments(long projectId, long assignmentId)
    {
        var query = new GetAllCommentsByAssignmentId(projectId, assignmentId);

        var response = await _sender.Send(query);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
    }

    [Authorize]
    [HttpPost("projects/{projectId}/assignments/{assignmentId}/comments")]
    public async Task<ActionResult> AddComment(long projectId, long assignmentId, CommentCreateRequest dto)
    {
        var command = new CreateCommentCommand(assignmentId, projectId, dto);

        var response = await _sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [Authorize]
    [HttpDelete("projects/assignments/comments/{commentId}")]
    public async Task<ActionResult> AddComment(long commentId)
    {
        var command = new DeleteCommentCommand(commentId);

        var response = await _sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize]
    [HttpPatch("projects/assignments/comments/{commentId}")]
    public async Task<ActionResult> UpdateComment(long commentId, UpdateCommentRequest dto)
    {
        var command = new UpdateCommentCommand(commentId, dto);

        var response = await _sender.Send(command);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
}
