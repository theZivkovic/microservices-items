
namespace Domain;

public sealed class Result<T>
{
    public T? Value { get; private set; }
    public Error? Error { get; private set; }
    public bool IsSuccess { get; private set; }

    private Result(T? value, Error? error)
    {
        if (value != null)
        {
            Value = value;
            IsSuccess = true;
            return;
        }
        if (error != null)
        {
            Error = error;
            IsSuccess = false;
            return;
        }
        throw new ArgumentException("Either value or error should be defined");
    }

    public bool IsFailure
    {
        get { return !IsSuccess; }
    }

    public static Result<T> Success(T Value)
    {
        return new Result<T>(Value, null);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(default!, error);
    }

    public static Result<T> Failure(ErrorCode errorCode)
    {
        return new Result<T>(default!, new Error(errorCode));
    }

    public Result<U> MapFailure<U>() where U : class
    {
        if (!IsSuccess)
        {
            throw new Exception("MapFailure can only be used on Error results");
        }
        return Result<U>.Failure(Error!);
    }

    public Result<U> Map<U>(Func<T, U> mapFunc)
    {
        return IsFailure
            ? Result<U>.Failure(Error!)
            : Result<U>.Success(mapFunc(Value!));
    }

    public async Task<Result<U>> MapAsync<U>(Func<T, Task<U>> mapFunc)
    {
        return IsFailure
            ? Result<U>.Failure(Error!)
            : Result<U>.Success(await mapFunc(Value!));
    }
}