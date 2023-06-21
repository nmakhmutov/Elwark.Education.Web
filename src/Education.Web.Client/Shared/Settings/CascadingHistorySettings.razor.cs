using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Shared.Settings;

[Obsolete]
public sealed partial class CascadingHistorySettings
{
    private const string StorageKey = "set.hst";

    private HistorySettings _settings = new()
    {
        QuizEpoch = EpochType.None,
        QuizDifficulty = null,

        EventGuesserEpoch = EpochType.None,
        EventGuesserType = null
    };

    [Inject]
    private ILocalStorageService Storage { get; set; } = default!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public EpochType QuizEpoch =>
        _settings.QuizEpoch;

    public DifficultyType? QuizDifficulty =>
        _settings.QuizDifficulty;

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

    public ValueTask ChangeQuizEpochAsync(EpochType epoch) =>
        UpdateStateAsync(_settings with { QuizEpoch = epoch });

    public ValueTask ChangeQuizDifficultyAsync(DifficultyType? type) =>
        UpdateStateAsync(_settings with { QuizDifficulty = type });

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

    [Obsolete]
    private sealed record HistorySettings
    {
        [JsonPropertyName("qe")]
        public EpochType QuizEpoch { get; init; }

        [JsonPropertyName("qd")]
        public DifficultyType? QuizDifficulty { get; init; }

        [JsonPropertyName("ege")]
        public EpochType EventGuesserEpoch { get; init; }

        [JsonPropertyName("egt")]
        public string? EventGuesserType { get; init; }
    }
}
