﻿using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Users;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Projects.PartilUpdate;

public class PartialUpdateProjectCommandHandler
    (
        IProjectRepository projectRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    : ICommandHandler<PartialUpdateProjectCommand, Result>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result> Handle(PartialUpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var leader = request.Data.LeaderId > 0 ? await _userRepository.GetByIdAsync((long)request.Data.LeaderId) : null;

        if (leader is null) return Result.Failure(UserErrors.UserNotFound);

        var projectToUpdate = await _projectRepository.GetByIdAsync(request.projectId);

        if (projectToUpdate is null) return Result.Failure(ProjectErrors.ProjectNotFound);

        _mapper.Map(request.Data, projectToUpdate);
        
        if 
        (
            request.Data.LeaderId > 0 &&
            !projectToUpdate.Employees.Any(employee => employee.Id == request.Data.LeaderId)
        )
        {
            projectToUpdate.Employees.Add(leader);  
        }

        _projectRepository.Update(projectToUpdate);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

