namespace Education.Web.Client.Services.Api;

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

    public bool IsLoaded =>
        Status != Status.Loading;

    public T Data =>
        _data ?? throw new ArgumentNullException(nameof(Data));

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
    Fail,
    Success
}
