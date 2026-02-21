using AskingKitten.Application.Extensions;
using AskingKitten.Application.FulltextSearch;
using AskingKitten.Application.Questions.Failures;
using AskingKitten.Application.Questions.Failures.Exceptions;
using AskingKitten.Contracts;
using AskingKitten.Contracts.Questions;
using AskingKitten.Entities.Questions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;

namespace AskingKitten.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ISearchProvider _searchProvider;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IQuestionsRepository questionsRepository,
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger,
        ISearchProvider searchProvider)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _logger = logger;
        _searchProvider = searchProvider;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // Request validation
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new QuestionValidationException(validationResult.ToErrors());
        }

        // Business logic validation
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount >= 3)
        {
            throw new TooManyOpenQuestionsException();
        }

        // Implementation of the Question entity's logic
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        var existQuestion = await _questionsRepository.GetByIdAsync(Guid.Empty, cancellationToken);

        await _searchProvider.IndexQuestionAsync(question, cancellationToken);

        await _questionsRepository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Question {questionId} created successfully", questionId);

        return questionId;
    }

// public async Task<IActionResult> Update(
//         Guid questionId,
//         UpdateQuestionDto request,
//         CancellationToken cancellationToken)
//
//     public async Task<IActionResult> SelectSolution(
//         Guid questionId,
//         Guid solutionId,
//         CancellationToken cancellationToken)
//
//     public async Task<IActionResult> AddSolution(
//         Guid questionId,
//         AddSolutionDto request,
//         CancellationToken cancellationToken)
}