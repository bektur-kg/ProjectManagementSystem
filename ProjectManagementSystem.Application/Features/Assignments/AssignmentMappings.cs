using AutoMapper;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Application.Features.Assignments;

public class AssignmentMappings : Profile
{
    public AssignmentMappings()
    {
        CreateMap<Assignment, AssignmentResponse>();
        CreateMap<AddAssignmentRequest, Assignment>();
        CreateMap<PartialUpdateAssignmentRequest, Assignment>()
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
        CreateMap<Assignment, AssignmentDetailedResponse>();

    }
}

