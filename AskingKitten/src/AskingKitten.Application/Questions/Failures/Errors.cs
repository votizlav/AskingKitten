using Shared;

namespace AskingKitten.Application.Questions.Failures;

public partial class Errors
{
    public static class Questions
    {
        public static Error TooManyOpenQuestions()
            => Error.Failure("too.many.open.questions", "User has reached the maximum number (3) of open questions");
    }
}