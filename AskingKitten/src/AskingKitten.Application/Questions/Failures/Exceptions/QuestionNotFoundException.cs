using AskingKitten.Application.Exceptions;
using Shared;

namespace AskingKitten.Application.Questions.Failures.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException(Error error)
        : base(error)
    {
    }
}