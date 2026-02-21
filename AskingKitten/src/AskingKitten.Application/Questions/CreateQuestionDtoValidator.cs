using AskingKitten.Contracts.Questions;
using FluentValidation;

namespace AskingKitten.Application.Questions;

public class CreateQuestionDtoValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionDtoValidator()
    {
        RuleFor(q => q.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(500).WithMessage("Title is too long");

        RuleFor(q => q.Text)
            .NotEmpty().WithMessage("Text is required")
            .MaximumLength(5000).WithMessage("Text is too long");

        RuleFor(q => q.UserId)
            .NotEmpty().WithMessage("User is required");

        RuleForEach(q => q.TagIds)
            .NotEmpty().WithMessage("Tag is required");
    }
}