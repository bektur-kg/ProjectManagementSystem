using MediatR;

namespace ProjectManagementSystem.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;
