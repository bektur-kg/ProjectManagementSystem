using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Constants;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Application.Features.Projects.AddEmployee;
using ProjectManagementSystem.Application.Features.Projects.Create;
using ProjectManagementSystem.Application.Features.Projects.Delete;
using ProjectManagementSystem.Application.Features.Projects.GetAll;
using ProjectManagementSystem.Application.Features.Projects.GetById;
using ProjectManagementSystem.Application.Features.Projects.GetCurrentUserProjects;
using ProjectManagementSystem.Application.Features.Projects.PartialUpdate;
using ProjectManagementSystem.Application.Features.Projects.RemoveEmployee;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("api")]
public class ProjectsController(ISender sender) : ControllerBase
{
    [Authorize(Roles = UserRoleMatches.Leader)]
    [HttpGet("projects")]
    public async Task<ActionResult<ProjectResponse>> GetAll()
    {
        var query = new GetAllProjectsQuery();

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.ProjectManagerOrEmployee)]
    [HttpGet("current-user/projects")]
    public async Task<ActionResult<ProjectResponse>> GetCurrentUserProjects()
    {
        var query = new GetCurrentUserProjectsQuery();

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
    }

    [Authorize]
    [HttpGet("projects/{id}", Name = "GetProjectById")]
    public async Task<ActionResult<ProjectResponse>> GetProjectById(long id)
    {
        var query = new GetProjectByIdQuery(id);

        var response = await sender.Send(query);

        if (response.IsSuccess) return Ok(response.Data);
        if (response.Error.Code == ProjectErrors.NotAccessible.Code) return Unauthorized(response.Error);
        return BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.Leader)]
    [HttpPost("projects")]
    public async Task<ActionResult<ProjectResponse>> CreateProject(CreateProjectRequest dto)
    {
        var query = new CreateProjectCommand(dto);

        var response = await sender.Send(query);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpPatch("projects/{id}")]
    public async Task<ActionResult<ProjectResponse>> PartialChangeProject(long id, PartialChangeProjectRequest dto)
    {
        var query = new PartialUpdateProjectCommand(id, dto);

        var response = await sender.Send(query);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.Leader)]
    [HttpDelete("projects/{id}")]
    public async Task<ActionResult<ProjectResponse>> DeleteProject(long id)
    {
        var query = new DeleteProjectCommand(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpPost("projects/{id}/employees")]
    public async Task<ActionResult<ProjectResponse>> AddEmployee(long id, long employeeId)
    {
        var query = new AddEmployeeToProjectComand(id, employeeId);

        var response = await sender.Send(query);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [Authorize(Roles = UserRoleMatches.LeaderOrManager)]
    [HttpDelete("projects/{id}/employees")]
    public async Task<ActionResult<ProjectResponse>> RemoveEmployee(long id, long employeeId)
    {
        var query = new RemoveEmployeeFromProjectCommand(id, employeeId);

        var response = await sender.Send(query);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
