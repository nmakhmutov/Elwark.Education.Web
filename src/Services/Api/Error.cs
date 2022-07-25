namespace Education.Web.Services.Api;

public sealed record Error
{
    public string Type { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;

    public int Status { get; init; } = 400;

    public string? Detail { get; init; }
    
    public string? Id { get; init; }
    
    public IDictionary<string, string[]> Errors { get; init; } = new Dictionary<string, string[]>();

    public static Error Create(string title, int status, string? detail = null) =>
        new()
        {
            Title = title,
            Status = status,
            Detail = detail
        };
}
