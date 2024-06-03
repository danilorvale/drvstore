using Drv.Store.Shared.Validation;

namespace Drv.Store.Order.Api.Extensions;

public static class FailureRequestHandler
{
    public static IResult HandleFailure(this Result result)
    {
        if (result.IsSuccess)throw new InvalidOperationException();
        else if(result.IsFailure && result.Error.Code.Contains("NotFound")) return Results.NoContent();
        else if ( result.GetType().GetInterfaces().FirstOrDefault() == typeof(IValidationResult))
            return Results.BadRequest(CreateProblemDetails(
                "Validation Error", StatusCodes.Status400BadRequest,
                result.Error,
                ((IValidationResult) result).Errors));
        else return Results.BadRequest(CreateProblemDetails(
            "Bad Request",
            StatusCodes.Status400BadRequest,
            result.Error));
    }

    private static ExceptionDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new(status, error.Code, title, error.Message, errors);

    private record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<Error>? Errors);
}