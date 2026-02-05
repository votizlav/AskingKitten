namespace AskingKitten.Contracts;

public record ReceiveQuestionDto(string Search, Guid[] TagIds, int Page, int PageSize);