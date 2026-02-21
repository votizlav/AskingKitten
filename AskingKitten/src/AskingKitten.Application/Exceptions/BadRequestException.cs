using System.Text.Json;
using Shared;

namespace AskingKitten.Application.Exceptions;

public class BadRequestException : Exception
{
    protected BadRequestException(Error[] error)
        : base(JsonSerializer.Serialize(error))
    {
    }
}