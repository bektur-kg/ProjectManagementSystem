using MediatR;

namespace ProjectManagementSystem.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>;