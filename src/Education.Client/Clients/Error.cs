namespace Education.Client.Clients;

public sealed record Error
{
    public required string Type { get; init; } = string.Empty;

    public required string Title { get; init; } = string.Empty;

    public required int Status { get; init; }

    public string? Detail { get; init; }

    public string? Id { get; init; }

    public static Error Create(string title, int status, string? detail = null) =>
        new()
        {
            Title = title,
            Status = status,
            Detail = detail,
            Type = "Client:Error"
        };
}
