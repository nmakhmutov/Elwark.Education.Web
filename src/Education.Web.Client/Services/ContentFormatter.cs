using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Education.Web.Client.Services;

public sealed class ContentFormatter : IDisposable
{
    private const double MinFontSize = 1;
    private const double MaxFontSize = 2;

    private const double MinLineHeight = 0.5;
    private const double MaxLineHeight = 2.5;

    private const string StorageKey = "fmt.srv";

    private readonly HashSet<StateChangedSubscription> _subscriptions = [];
    private readonly ILocalStorageService _storage;
    private bool _isInitialized;
    private State _state;

    public ContentFormatter(ILocalStorageService storage)
    {
        _isInitialized = false;
        _storage = storage;
        _state = new State();
    }

    public Align TextAlign =>
        _state.TextAlign;

    public double FontSize =>
        _state.FontSize;

    public double LineHeight =>
        _state.LineHeight;

    public bool IsFontWeightBold =>
        _state.IsFontWeightBold;

    public bool CanIncreaseFontSize =>
        FontSize < MaxFontSize;

    public bool CanDecreaseFontSize =>
        FontSize > MinFontSize;

    public bool CanIncreaseLineHeight =>
        LineHeight < MaxLineHeight;

    public bool CanDecreaseLineHeight =>
        LineHeight > MinLineHeight;

    public async ValueTask InitializeAsync()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        var result = await _storage.GetItemAsync<State>(StorageKey);
        if (result is null)
            return;

        _state = result with
        {
            FontSize = result.FontSize switch
            {
                < MinFontSize => MinFontSize,
                > MaxFontSize => MaxFontSize,
                _ => result.FontSize
            },
            LineHeight = result.LineHeight switch
            {
                < MinLineHeight => MinLineHeight,
                > MaxLineHeight => MaxLineHeight,
                _ => result.LineHeight
            }
        };
    }

    public IDisposable NotifyOnChange(EventCallback callback)
    {
        var subscription = new StateChangedSubscription(this, callback);
        _subscriptions.Add(subscription);

        return subscription;
    }

    public Task IncreaseFontSizeAsync() =>
        UpdateAsync(_state with { FontSize = Math.Min(MaxFontSize, Math.Round(_state.FontSize + 0.1, 2)) });

    public Task DecreaseFontSizeAsync() =>
        UpdateAsync(_state with { FontSize = Math.Max(MinFontSize, Math.Round(_state.FontSize - 0.1, 2)) });

    public Task IncreaseLineHeightAsync() =>
        UpdateAsync(_state with { LineHeight = Math.Min(MaxLineHeight, Math.Round(_state.LineHeight + 0.1, 2)) });

    public Task DecreaseLineHeightAsync() =>
        UpdateAsync(_state with { LineHeight = Math.Max(MinLineHeight, Math.Round(_state.LineHeight - 0.1, 2)) });

    public Task AlignTextLeftAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Left });

    public Task AlignTextRightAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Right });

    public Task AlignTextCenterAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Center });

    public Task AlignTextJustifyAsync() =>
        UpdateAsync(_state with { TextAlign = Align.Justify });

    public Task ToggleFontWeightAsync() =>
        UpdateAsync(_state with { IsFontWeightBold = !_state.IsFontWeightBold });

    private async Task UpdateAsync(State state)
    {
        await _storage.SetItemAsync(StorageKey, _state = state);

        await Task.WhenAll(_subscriptions.Select(s => s.NotifyAsync()));
    }

    private sealed record State
    {
        [JsonPropertyName("ta")]
        public Align TextAlign { get; init; } = Align.Left;

        [JsonPropertyName("fs")]
        public double FontSize { get; init; } = 1;

        [JsonPropertyName("lh")]
        public double LineHeight { get; init; } = 1;

        [JsonPropertyName("fw")]
        public bool IsFontWeightBold { get; init; }
    }

    private sealed class StateChangedSubscription : IDisposable
    {
        private readonly ContentFormatter _owner;
        private readonly EventCallback _callback;

        public StateChangedSubscription(ContentFormatter owner, EventCallback callback)
        {
            _owner = owner;
            _callback = callback;
        }

        public void Dispose() =>
            _owner._subscriptions.Remove(this);

        public Task NotifyAsync() =>
            _callback.InvokeAsync();
    }

    public void Dispose()
    {
        _subscriptions.Clear();
    }
}
