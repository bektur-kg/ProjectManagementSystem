using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectManagementSystem.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}

