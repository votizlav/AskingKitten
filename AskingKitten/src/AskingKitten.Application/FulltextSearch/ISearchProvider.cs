using AskingKitten.Entities.Questions;

namespace AskingKitten.Application.FulltextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query, CancellationToken cancellationToken);

    Task IndexQuestionAsync(Question question, CancellationToken cancellationToken);
}