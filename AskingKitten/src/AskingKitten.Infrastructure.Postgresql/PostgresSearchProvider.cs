using AskingKitten.Application.FulltextSearch;
using AskingKitten.Entities.Questions;

namespace AskingKitten.Infrastructure.Postgresql;

public class PostgresSearchProvider : ISearchProvider
{
    public Task IndexQuestionAsync(Question question, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task<List<Guid>> SearchAsync(string query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<Guid>());
    }
}