using AskingKitten.Contracts.Questions;
using FluentValidation;

namespace AskingKitten.Application.Questions;

public class CreateQuestionDtoValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionDtoValidator()
    {
        RuleFor(q => q.Title).NotEmpty().MaximumLength(500).WithMessage("Title is required or too long");
        
        RuleFor(q => q.Text).NotEmpty().MaximumLength(5000).WithMessage("Text is required or too long");

        RuleFor(q => q.UserId).NotEmpty();
        
        RuleForEach(q => q.TagIds).NotEmpty();
    }
}