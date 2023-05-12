using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Shared.Settings;

public sealed partial class CascadingHistorySettings
{
    private const string StorageKey = "set.hst";

    private HistorySettings _settings = new()
    {
        SearchRandomEpoch = EpochType.None,

        TestEpoch = EpochType.None,
        QuizType = null,

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

    public QuizType? QuizType =>
        _settings.QuizType;

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

    public ValueTask ChangeTestTypeAsync(QuizType? type) =>
        UpdateStateAsync(_settings with { QuizType = type });

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
        public EpochType SearchRandomEpoch { get; init; }

        [JsonPropertyName("te")]
        public EpochType TestEpoch { get; init; }

        [JsonPropertyName("qt")]
        public QuizType? QuizType { get; init; }

        [JsonPropertyName("ege")]
        public EpochType EventGuesserEpoch { get; init; }

        [JsonPropertyName("egt")]
        public string? EventGuesserType { get; init; }
    }
}
