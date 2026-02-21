using AskingKitten.Application.FulltextSearch;
using AskingKitten.Entities.Questions;

namespace AskingKitten.Infrastructure.ElasticSearch;

public class ElasticSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<Guid>());
    }

    public Task IndexQuestionAsync(Question question, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}