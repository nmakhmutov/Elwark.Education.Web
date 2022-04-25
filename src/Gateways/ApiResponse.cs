namespace Education.Web.Gateways;

public sealed class ApiResponse<T>
{
    private readonly T? _data;
    private readonly Error? _error;

    private ApiResponse(ResponseStatus status, T? data, Error? error = null)
    {
        Status = status;
        _data = data;
        _error = error;
    }

    public ResponseStatus Status { get; }

    public bool IsSuccess =>
        Status == ResponseStatus.Success;

    public bool IsLoaded =>
        Status != ResponseStatus.Loading;

    public T Data =>
        _data ?? throw new ArgumentNullException(nameof(Data));

    public Error Error =>
        _error ?? throw new ArgumentNullException(nameof(Error));

    public static ApiResponse<T> Loading() =>
        new(ResponseStatus.Loading, default);

    public static ApiResponse<T> Success(T data) =>
        new(ResponseStatus.Success, data);

    public static ApiResponse<T> Fail(Error error) =>
        new(ResponseStatus.Fail, default, error);
}

public enum ResponseStatus
{
    Loading,
    Fail,
    Success
}
