namespace Education.Web.Client.Http;

public sealed class ApiResult<T>
{
    private readonly T? _data;
    private readonly Error? _error;

    private ApiResult(Status status, T? data, Error? error = null)
    {
        Status = status;
        _data = data;
        _error = error;
    }

    public Status Status { get; }

    public bool IsSuccess =>
        Status == Status.Success;

    public bool IsFailed =>
        Status == Status.Fail;

    public T Value =>
        _data ?? throw new ArgumentNullException(nameof(Value));

    public Error Error =>
        _error ?? throw new ArgumentNullException(nameof(Error));

    public static ApiResult<T> Loading() =>
        new(Status.Loading, default);

    public static ApiResult<T> Success(T data) =>
        new(Status.Success, data);

    public static ApiResult<T> Fail(Error error) =>
        new(Status.Fail, default, error);
}

public enum Status
{
    Loading,
    Success,
    Fail
}
