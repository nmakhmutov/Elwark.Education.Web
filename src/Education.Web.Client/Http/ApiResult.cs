using System.Diagnostics;

namespace Education.Web.Client.Http;

public sealed class ApiResult<T>
{
    private readonly Error? _error;
    private readonly T? _value;

    private ApiResult()
    {
        Status = Status.Loading;
        _value = default;
        _error = null;
    }

    private ApiResult(T value)
    {
        Status = Status.Success;
        _value = value;
        _error = null;
    }

    private ApiResult(Error error)
    {
        Status = Status.Error;
        _value = default;
        _error = error;
    }

    public Status Status { get; }

    public bool IsSuccess =>
        Status == Status.Success;

    public bool IsError =>
        Status == Status.Error;

    public T Value =>
        _value ?? throw new ArgumentNullException(nameof(Value));

    public Error Error =>
        _error ?? throw new ArgumentNullException(nameof(Error));

    public static ApiResult<T> Loading() =>
        new();

    public static ApiResult<T> Success(T data) =>
        new(data);

    public static ApiResult<T> Fail(Error error) =>
        new(error);

    public U Match<U>(Func<T, U> success, Func<Error, U> error, Func<U> loading) =>
        Status switch
        {
            Status.Loading => loading(),
            Status.Success => success(Value),
            Status.Error => error(Error),
            _ => throw new UnreachableException($"Unknown status {Status}")
        };

    public void Match(Action<T> success)
    {
        if (IsSuccess)
            success(Value);
    }

    public async Task Match(Func<T, Task> success)
    {
        if (IsSuccess)
            await success(Value);
    }

    public void Match(Action<T> success, Action<Error> error)
    {
        if (IsSuccess)
            success(Value);
        else if (IsError)
            error(Error);
    }

    public ApiResult<U> Map<U>(Func<T, U> fn) =>
        Match(x => ApiResult<U>.Success(fn(x)), ApiResult<U>.Fail, ApiResult<U>.Loading);

    public ApiResult<T> Or(Func<T> fn) =>
        Match(Success, _ => Success(fn()), () => Success(fn()));

    public T Unwrap() =>
        _value ?? throw new ArgumentNullException(nameof(Value));

    public T UnwrapOr(T defaultValue) =>
        Match(value => value, _ => defaultValue, () => defaultValue);

    public T UnwrapOrElse(Func<T> fn) =>
        Match(value => value, _ => fn(), fn);

    public Error UnwrapError() =>
        _error ?? throw new ArgumentNullException(nameof(Error));

    public override string ToString()
    {
        if (_value is not null)
            return _value.ToString() ?? "Data is null";

        if (_error is not null)
            return _error.ToString();

        return Status.ToString();
    }
}

public enum Status
{
    Loading,
    Success,
    Error
}
