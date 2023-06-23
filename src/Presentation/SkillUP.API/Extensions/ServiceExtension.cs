using Microsoft.AspNetCore.Mvc;

namespace SkillUP.API.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddAppVersion(this IServiceCollection services)
    {
        return services.AddApiVersioning(cfg => {
            cfg.DefaultApiVersion = new ApiVersion(1, 0);
            cfg.AssumeDefaultVersionWhenUnspecified = true;
            cfg.ReportApiVersions = true;
        });
    }
}
