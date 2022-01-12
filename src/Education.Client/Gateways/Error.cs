namespace Education.Client.Gateways;

public sealed record Error
{
    public Error(string title, string type, string? detail, int status, Dictionary<string, string[]>? errors)
    {
        Title = title;
        Type = type;
        Detail = detail;
        Status = status;
        Errors = errors ?? new Dictionary<string, string[]>();
    }

    public string Title { get; }

    public string Type { get; }

    public string? Detail { get; }

    public int Status { get; }

    public Dictionary<string, string[]> Errors { get; } = new();

    public string Message => Detail ?? Title;

    public bool IsNotFound() =>
        Type == "not-found";

    public bool IsExpired() =>
        Type == "expired";

    public static Error Create(string title, string type, int status) =>
        new(title, type, null, status, new Dictionary<string, string[]>());
}
