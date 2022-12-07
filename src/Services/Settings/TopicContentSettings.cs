using System.Globalization;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using MudBlazor;
using MudBlazor.Utilities;

namespace Education.Web.Services.Settings;

internal sealed class TopicContentSettings
{
    private const double MinTextSize = 1;
    private const double MaxTextSize = 2;
    private const string StorageKey = "tcfs";

    private readonly ILocalStorageService _storage;
    private State _state;
    private bool _isInitialized;

    public TopicContentSettings(ILocalStorageService storage)
    {
        _storage = storage;
        _state = new State
        {
            TextAlign = Align.Left,
            FontSize = MinTextSize
        };
    }

    public Align TextAlign =>
        _state.TextAlign;

    public double FontSize =>
        _state.FontSize switch
        {
            < MinTextSize => MinTextSize,
            > MaxTextSize => MaxTextSize,
            _ => _state.FontSize
        };

    public string TextStyles =>
        StyleBuilder.Default("font-size", $"{FontSize.ToString("0.0", CultureInfo.InvariantCulture)}rem")
            .AddStyle("text-align", TextAlign switch
            {
                Align.Left => "left",
                Align.Start => "left",
                Align.Right => "right",
                Align.End => "right",
                Align.Center => "center",
                Align.Justify => "justify",
                _ => "inherit"
            })
            .Build();

    public bool CanIncreaseFont =>
        FontSize < MaxTextSize;

    public bool CanDecreaseFont =>
        FontSize > MinTextSize;

    public event Action OnChange = () => { };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        var result = await _storage.GetItemAsync<State>(StorageKey);
        if (result is null)
            return;

        _state = result;
    }

    public ValueTask IncreaseFontAsync() =>
        CanIncreaseFont
            ? UpdateAsync(_state with { FontSize = Math.Round(_state.FontSize + 0.1, 2) })
            : ValueTask.CompletedTask;

    public ValueTask DecreaseFontAsync() =>
        CanDecreaseFont
            ? UpdateAsync(_state with { FontSize = Math.Round(_state.FontSize - 0.1, 2) })
            : ValueTask.CompletedTask;

    public ValueTask AlignTextLeftAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Left });

    public ValueTask AlignTextRightAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Right });

    public ValueTask AlignTextCenterAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Center });

    public ValueTask AlignTextJustifyAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Justify });

    private ValueTask UpdateAsync(State state)
    {
        OnChange();
        return _storage.SetItemAsync(StorageKey, _state = state);
    }

    private sealed record State
    {
        [JsonPropertyName("ta")]
        public required Align TextAlign { get; init; }

        [JsonPropertyName("fs")]
        public required double FontSize { get; init; }
    }
}
