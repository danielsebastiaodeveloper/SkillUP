using Microsoft.Extensions.DependencyInjection;
using SkillUP.Domain.Interfaces;
using SkillUP.Shared.Services;

namespace SkillUP.Shared;

public static class DependencyContainer
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeService, DateTimeService>();
        return services;
    }
}
