namespace Drv.Store.Shared.Exceptions;

public class ValidationException(IReadOnlyCollection<ValidationError> errors) : Exception("Validation failed")
{
    public IReadOnlyCollection<ValidationError> Errors { get; } = errors;
}

public abstract record ValidationError(string PropertyName, string ErrorMessage);