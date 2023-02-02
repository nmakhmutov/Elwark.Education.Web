using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web.Client.Features.History.Services;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Shared.State.Settings;

public sealed partial class CascadingHistorySettings
{
    private const string StorageKey = "set.hst";

    private HistorySettings _settings = new()
    {
        SearchRandomEpoch = EpochType.None,

        TestEpoch = EpochType.None,
        TestType = null,

        EventGuesserEpoch = EpochType.None,
        EventGuesserType = null
    };

    [Inject]
    private ILocalStorageService Storage { get; set; } = default!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public EpochType SearchRandomEpoch =>
        _settings.SearchRandomEpoch;

    public EpochType TestEpoch =>
        _settings.TestEpoch;

    public string? TestType =>
        _settings.TestType;

    public EpochType EventGuesserEpoch =>
        _settings.EventGuesserEpoch;

    public string? EventGuesserType =>
        _settings.EventGuesserType;

    protected override async Task OnInitializedAsync()
    {
        var result = await Storage.GetItemAsync<HistorySettings>(StorageKey);
        if (result is null)
            return;

        _settings = result;
    }

    public ValueTask ChangeSearchRandomEpochAsync(EpochType epoch) =>
        UpdateStateAsync(_settings with { SearchRandomEpoch = epoch });

    public ValueTask ChangeTestEpochAsync(EpochType epoch) =>
        UpdateStateAsync(_settings with { TestEpoch = epoch });

    public ValueTask ChangeTestTypeAsync(string? type) =>
        UpdateStateAsync(_settings with { TestType = type });

    public ValueTask ChangeEventGuesserEpochAsync(EpochType epoch) =>
        UpdateStateAsync(_settings with { EventGuesserEpoch = epoch });

    public ValueTask ChangeEventGuesserTypeAsync(string? type) =>
        UpdateStateAsync(_settings with { EventGuesserType = type });

    private ValueTask UpdateStateAsync(HistorySettings settings)
    {
        _settings = settings;
        StateHasChanged();

        return Storage.SetItemAsync(StorageKey, _settings);
    }

    private sealed record HistorySettings
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
}
