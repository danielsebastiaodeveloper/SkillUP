using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillUP.Domain.Interfaces.Repositories;
using SkillUP.Persistence.Contexts;
using SkillUP.Persistence.Repositories;

namespace SkillUP.Persistence;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {

        string connString = configuration.GetConnectionString("MySQLDb") ?? default!;
        services.AddSingleton(new SkillUPDapperDbContext(connString));
        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}
