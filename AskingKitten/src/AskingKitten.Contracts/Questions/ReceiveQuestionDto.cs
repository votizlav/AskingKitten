namespace AskingKitten.Contracts.Questions;

public record ReceiveQuestionDto(string Search, Guid[] TagIds, int Page, int PageSize);