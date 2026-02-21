using AskingKitten.Application.Exceptions;
using Shared;

namespace AskingKitten.Application.Questions.Failures.Exceptions;

public class TooManyOpenQuestionsException : BadRequestException
{
    public TooManyOpenQuestionsException()
        : base([Errors.Questions.TooManyOpenQuestions()])
    {
    }
}