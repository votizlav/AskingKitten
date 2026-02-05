using Microsoft.AspNetCore.Mvc;
using AskingKitten.Contracts;
namespace AskingKitten.Presenters;

[ApiController]
[Route("[controller]")]
public class SolutionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateQuestionDto request)
    {
        return Ok("Question created successfully"); 
    }
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] ReceiveQuestionDto request, 
        CancellationToken cancellationToken)
    {
        return Ok("Questions received successfully");
    }
    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid questionId, 
        CancellationToken cancellationToken)
    {
        return Ok("Question received successfully");
    }
    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid questionId, 
        [FromBody] UpdateQuestionDto request, 
        CancellationToken cancellationToken)
    {
        return Ok("Question updated successfully");
    }
    [HttpPatch("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution(
        [FromRoute] Guid questionId, 
        [FromQuery] Guid solutionId, 
        CancellationToken cancellationToken)
    {
        return Ok("Solution selected successfully");
    }
    [HttpPost("{questionId:guid}")]
    public async Task<IActionResult> AddSolution(
        [FromRoute] Guid questionId, 
        [FromBody] AddSolutionDto request, 
        CancellationToken cancellationToken)
    {
        return Ok("Solution added successfully");
    }
}