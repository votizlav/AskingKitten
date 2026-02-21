using System.Text.Json;
using Shared;

namespace AskingKitten.Application.Exceptions;

public class NotFoundException : Exception
{
    protected NotFoundException(Error error)
        : base(JsonSerializer.Serialize(error))
    {
    }
}