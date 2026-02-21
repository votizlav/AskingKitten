using AskingKitten.Application.Exceptions;
using Shared;

namespace AskingKitten.Application.Questions.Failures.Exceptions;

public class QuestionValidationException : BadRequestException
{
    public QuestionValidationException(Error[] errors)
        : base(errors)
    {
    }
}