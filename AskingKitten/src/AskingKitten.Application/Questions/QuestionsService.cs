using AskingKitten.Contracts;
using AskingKitten.Contracts.Questions;
using AskingKitten.Entities.Questions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AskingKitten.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IQuestionsRepository questionsRepository, 
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _logger = logger; 
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // Request validation
        
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        // Business logic validation
        
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);
        
        if (openUserQuestionsCount >= 3)
        {
            throw new Exception("User has reached the maximum number (3) of open questions");
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

        // Saving entity Question in database
        
        await _questionsRepository.AddAsync(question, cancellationToken);
        
        _logger.LogInformation("Question {questionId} created successfully", questionId);
         
        return questionId;
        // Saving status logging
    }

//     public async Task<IActionResult> Update(
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