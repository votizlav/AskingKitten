using AskingKitten.Application;
using AskingKitten.Infrastructure.ElasticSearch;
using AskingKitten.Infrastructure.Postgresql;

namespace AskingKitten.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddWebDependencies()
            .AddApplication()
            .AddPostgresInfrastructure()
            .AddElasticSearchInfrastructure();
        return services;
    }

    public static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}