using SkillUP.API.Midlewares;

namespace SkillUP.API.Extensions;

public static class ApiExtensions
{
    public static void UseErrorHandlerMidleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMidleware>();
    }
}
