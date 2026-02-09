using AskingKitten.Contracts.Questions;

namespace AskingKitten.Application.Questions;

public interface IQuestionsService
{
    Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
}