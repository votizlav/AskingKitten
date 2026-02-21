namespace Shared;

public record Error
{
    public string Code { get; }

    public string Message { get; }

    public ErrorType Type { get; }

    public string? InvalidField { get; }

    private Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;

    }

    public static Error NotFound(string? code, string message, Guid? id)
        => new(code ?? "record.not.found", message, ErrorType.NOT_FOUND, id?.ToString());

    public static Error Validation(string? code, string message, string invalidField = null)
        => new(code ?? "value.is.invalid", message, ErrorType.VALIDATION, invalidField ?? "value");

    public static Error Conflict(string? code, string message)
        => new(code ?? "conflict.error", message, ErrorType.CONFLICT);

    public static Error Failure(string? code, string message)
        => new(code ?? "failure.error", message, ErrorType.FAILURE);
}

public enum ErrorType
{
    /// <summary>
    /// validation error.
    /// </summary>
    VALIDATION,

    /// <summary>
    /// not found error.
    /// </summary>
    NOT_FOUND,

    /// <summary>
    /// server failure error.
    /// </summary>
    FAILURE,

    /// <summary>
    /// configuration error.
    /// </summary>
    CONFLICT,
}