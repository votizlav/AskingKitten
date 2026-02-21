using AskingKitten.Application.FulltextSearch;
using AskingKitten.Application.Questions;
using AskingKitten.Infrastructure.ElasticSearch;
using Microsoft.Extensions.DependencyInjection;

namespace AskingKitten.Infrastructure.ElasticSearch;

public static class DependencyInjection
{
    public static IServiceCollection AddElasticSearchInfrastructure(this IServiceCollection services) =>
        services.AddScoped<ISearchProvider, ElasticSearchProvider>();
}