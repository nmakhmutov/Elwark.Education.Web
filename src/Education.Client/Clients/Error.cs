using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Client.Clients;

public sealed record Error
{
    public required string Type { get; init; } = string.Empty;

    public required string Title { get; init; } = string.Empty;

    public required int Status { get; init; }

    public string? Detail { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement> Payload { get; init; } =
        new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);

    public static Error Create(string title, int status = 404, string? details = null) =>
        new()
        {
            Type = "Client:Error",
            Title = title,
            Status = status,
            Detail = details
        };
}
