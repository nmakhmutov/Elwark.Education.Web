using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Client.Clients;

public sealed record Error
{
    public required string Type { get; init; }

    public required string Title { get; init; }

    public required int Status { get; init; }

    public string? Detail { get; init; }

    public string UiMessage =>
        Detail ?? Title;

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
