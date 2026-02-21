using AskingKitten.Application.FulltextSearch;
using AskingKitten.Application.Questions;
using AskingKitten.Infrastructure.Postgresql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AskingKitten.Infrastructure.Postgresql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        // services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddDbContext<QuestionsDbContext>();

        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();

        return services;
    }
}