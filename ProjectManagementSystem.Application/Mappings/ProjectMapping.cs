using AutoMapper;
using ProjectManagementSystem.Application.Contracts.Project;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Mappings;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<Project, ProjectResponse>();
    }
}

