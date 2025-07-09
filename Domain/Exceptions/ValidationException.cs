using System.Net;

namespace Domain.Exceptions;

public class ValidationException : CustomException
{
    public ValidationException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.BadRequest)
    {
    }
}