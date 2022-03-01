using Blazored.LocalStorage;
using MudBlazor;

namespace Education.Client.Services;

internal sealed class ThemeService
{
    private const string StorageKey = "ts";
    private readonly ILocalStorageService _storage;

    public readonly MudTheme Theme = new()
    {
        Palette = new Palette
        {
            Primary = "#5569FF",
            Secondary = "#584BB0",
            Tertiary = "#8560C7",
            Info = "#33C2FF",
            Success = "#44D600",
            Warning = "#FFA319",
            Error = "#FF1943",
            Black = "#272C34",
            Background = "#F6F6F6",
            BackgroundGrey = "#E3E5E7",
            AppbarBackground = Colors.Shades.White,
            AppbarText = Colors.Grey.Darken3,
            Divider = "#E8E8E8",
            DividerLight = "#ECECEC",
            TableLines = "#E8E8E8",
            OverlayLight = "rgba(255, 255, 255, 0.7)"
        },
        PaletteDark = new Palette
        {
            Primary = "#5569ff",
            Secondary = "#584bb0",
            Tertiary = "#8560c7",
            Info = "#33c2ff",
            Success = "#44d600",
            Warning = "#ffa319",
            Error = "#ff1943",
            Black = "#27272f",
            Background = "#1c1c1c",
            BackgroundGrey = "#27272f",
            Surface = "#252525",
            DrawerBackground = "#090a0c",
            DrawerText = "rgba(255,255,255, 0.50)",
            AppbarBackground = "#090a0c",
            AppbarText = "rgba(255,255,255, 0.70)",
            Divider = "rgba(255, 255, 255, 0.1)",
            TableLines = "rgba(255, 255, 255, 0.1)",
            TextPrimary = "rgba(255,255,255, 0.70)",
            TextSecondary = "rgba(255,255,255, 0.50)",
            ActionDefault = "#adadb1",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            DrawerIcon = "rgba(255,255,255, 0.50)",
            HoverOpacity = 0.2,
            OverlayDark = "rgba(33, 33, 33, 0.7)"
        }
    };

    public ThemeService(ILocalStorageService storage)
    {
        _storage = storage;
        IsDarkMode = false;
    }

    public bool IsDarkMode { get; private set; }

    public string Icon =>
        IsDarkMode ? Icons.Outlined.DarkMode : Icons.Outlined.LightMode;

    public event Action OnChange = () => { };

    public async Task ToggleAsync()
    {
        await _storage.SetItemAsync(StorageKey, IsDarkMode = !IsDarkMode);
        OnChange();
    }

    public async Task InitAsync()
    {
        IsDarkMode = await _storage.GetItemAsync<bool>(StorageKey);
        OnChange();
    }
}
