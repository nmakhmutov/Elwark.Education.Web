using System.Text.Json.Serialization;
using Education.Web.Services.History;

namespace Education.Web.Components.Settings;

public sealed record HistorySettings
{
    [JsonPropertyName("sre")]
    public required EpochType SearchRandomEpoch { get; init; }

    [JsonPropertyName("te")]
    public required EpochType TestEpoch { get; init; }

    [JsonPropertyName("tt")]
    public required string? TestType { get; init; }

    [JsonPropertyName("ege")]
    public required EpochType EventGuesserEpoch { get; init; }

    [JsonPropertyName("egt")]
    public required string? EventGuesserType { get; init; }
}
