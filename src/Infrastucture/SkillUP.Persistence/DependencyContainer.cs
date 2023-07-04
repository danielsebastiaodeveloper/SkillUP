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

        string connString = GetConnectionStringFromEnv();
        services.AddSingleton(new SkillUPDapperDbContext(connString));
        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }

    private static string GetConnectionStringFromEnv()
    {
        var host = Environment.GetEnvironmentVariable("DBHOST");
        var dbport = Environment.GetEnvironmentVariable("DBPORT");
        var dbname = Environment.GetEnvironmentVariable("DBNAME");
        var user = Environment.GetEnvironmentVariable("DBUSER");
        var password = Environment.GetEnvironmentVariable("DBPASSWORD");

        var connectionString = $"Server={host};Port={dbport};Database={dbname};User={user};Password={password};";
        return connectionString;
    }
}
