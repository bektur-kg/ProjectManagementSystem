﻿using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.GetAll;

public class GetAllProjectsQuery : IQuery<DataResult<List<ProjectResponse>>>;

