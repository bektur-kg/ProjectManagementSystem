using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Contracts.Project;
using ProjectManagementSystem.Application.Features.Projects.GetAll;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(ISender sender) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<ProjectResponse>> GetAll()
    {
        var query = new GetAllProjectsQuery();

        var response = await sender.Send(query);

        if (response.IsSuccess)
        {
            return Ok(response.Data);
        }

        return BadRequest(response.Error);
    }
}
