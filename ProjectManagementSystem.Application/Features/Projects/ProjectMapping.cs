using AutoMapper;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Projects;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<Project, ProjectResponse>();
        CreateMap<Project, ProjectDetailedResponse>();
        CreateMap<CreateProjectRequest, Project>();
        CreateMap<PartialChangeProjectRequest, Project>()
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
    }
}

