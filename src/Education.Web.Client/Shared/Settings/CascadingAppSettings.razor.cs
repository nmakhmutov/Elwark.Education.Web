using System.Globalization;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;

namespace Education.Web.Client.Shared.Settings;

public sealed partial class CascadingAppSettings
{
    private const double MinTextSize = 1;
    private const double MaxTextSize = 2;
    private const string StorageKey = "set";

    private AppSettings _settings = new()
    {
        TextAlign = Align.Left,
        FontSize = MinTextSize,
        IsSidebarOpen = false
    };

    [Inject]
    private ILocalStorageService Storage { get; set; } = default!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public Align TextAlign =>
        _settings.TextAlign;

    public double FontSize =>
        _settings.FontSize;

    public bool IsSidebarOpen =>
        _settings.IsSidebarOpen;

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

    protected override async Task OnInitializedAsync()
    {
        var result = await Storage.GetItemAsync<AppSettings>(StorageKey);
        if (result is null)
            return;

        _settings = result with
        {
            FontSize = result.FontSize switch
            {
                < MinTextSize => MinTextSize,
                > MaxTextSize => MaxTextSize,
                _ => result.FontSize
            }
        };
    }

    public ValueTask IncreaseFontAsync() =>
        CanIncreaseFont
            ? UpdateAsync(_settings with { FontSize = Math.Round(_settings.FontSize + 0.1, 2) })
            : ValueTask.CompletedTask;

    public ValueTask DecreaseFontAsync() =>
        CanDecreaseFont
            ? UpdateAsync(_settings with { FontSize = Math.Round(_settings.FontSize - 0.1, 2) })
            : ValueTask.CompletedTask;

    public ValueTask AlignTextLeftAsync() =>
        UpdateAsync(_settings with { TextAlign = Align.Left });

    public ValueTask AlignTextRightAsync() =>
        UpdateAsync(_settings with { TextAlign = Align.Right });

    public ValueTask AlignTextCenterAsync() =>
        UpdateAsync(_settings with { TextAlign = Align.Center });

    public ValueTask AlignTextJustifyAsync() =>
        UpdateAsync(_settings with { TextAlign = Align.Justify });

    public ValueTask ToggleSidebarAsync(bool isOpen) =>
        UpdateAsync(_settings with { IsSidebarOpen = isOpen });

    private ValueTask UpdateAsync(AppSettings settings)
    {
        _settings = settings;
        StateHasChanged();

        return Storage.SetItemAsync(StorageKey, _settings);
    }

    private sealed record AppSettings
    {
        [JsonPropertyName("ta")]
        public Align TextAlign { get; init; }

        [JsonPropertyName("fs")]
        public double FontSize { get; init; } = 1;

        [JsonPropertyName("iso")]
        public bool IsSidebarOpen { get; init; }
    }
}
