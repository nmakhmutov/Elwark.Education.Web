using System.Globalization;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using MudBlazor;
using MudBlazor.Utilities;

namespace Education.Web.Services;

public sealed class TopicContentFormatService
{
    private const double MinTextSize = 1;
    private const double MaxTextSize = 2;
    private const string StorageKey = "tcfs";

    private readonly ILocalStorageService _storage;
    private bool _isInitialized;

    public TopicContentFormatService(ILocalStorageService storage)
    {
        _storage = storage;
        _isInitialized = false;
        TextAlign = Align.Left;
        FontSize = MinTextSize;
        TextStyles = string.Empty;

        UpdateStyles();
    }

    public Align TextAlign { get; private set; }

    public double FontSize { get; private set; }

    public string TextStyles { get; private set; }

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

        TextAlign = result.TextAlign;
        FontSize = result.FontSize switch
        {
            < MinTextSize => MinTextSize,
            > MaxTextSize => MaxTextSize,
            _ => result.FontSize
        };

        UpdateStyles();
    }

    public Task IncreaseFontAsync()
    {
        if (!CanIncreaseFont)
            return Task.CompletedTask;

        FontSize += 0.1;

        return Update();
    }

    public Task DecreaseFontAsync()
    {
        if (!CanDecreaseFont)
            return Task.CompletedTask;

        FontSize -= 0.1;

        return Update();
    }

    public Task AlignTextLeftAsync() =>
        AlignTextAsync(Align.Left);

    public Task AlignTextRightAsync() =>
        AlignTextAsync(Align.Right);

    public Task AlignTextCenterAsync() =>
        AlignTextAsync(Align.Center);

    public Task AlignTextJustifyAsync() =>
        AlignTextAsync(Align.Justify);

    private Task AlignTextAsync(Align align)
    {
        TextAlign = align;
        return Update();
    }

    private void UpdateStyles() =>
        TextStyles = StyleBuilder
            .Default("font-size", $"{FontSize.ToString("0.0", CultureInfo.InvariantCulture)}rem")
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

    private async Task Update()
    {
        UpdateStyles();

        await _storage.SetItemAsync(StorageKey, new State
        {
            FontSize = Math.Round(FontSize, 2),
            TextAlign = TextAlign
        });

        OnChange();
    }

    private sealed record State
    {
        [JsonPropertyName("ta")]
        public Align TextAlign { get; init; }

        [JsonPropertyName("fs")]
        public double FontSize { get; init; }
    }
}
