using MediatR;

namespace ProjectManagementSystem.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>;
