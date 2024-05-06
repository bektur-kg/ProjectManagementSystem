using Microsoft.Extensions.Options;
using ProjectManagementSystem.Infrastructure.Modules.Users;

namespace ProjectManagementSystem.API.OptionsSetup;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "JWT";

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
