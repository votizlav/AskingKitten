using FluentValidation.Results;
using Shared;

namespace AskingKitten.Application.Extensions;

public static class ValidationExtensions
{
    public static Error[] ToErrors(this ValidationResult validationResult)
        => validationResult.Errors.Select(e => Error.Validation(
            e.ErrorMessage, e.ErrorCode, e.PropertyName)).ToArray();
}