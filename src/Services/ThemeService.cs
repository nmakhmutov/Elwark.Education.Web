using Blazored.LocalStorage;
using MudBlazor;

namespace Education.Web.Services;

internal sealed class ThemeService
{
    private const string StorageKey = "ts";
    private readonly ILocalStorageService _storage;

    public readonly MudTheme Theme = new()
    {
        Palette = new Palette
        {
            Primary = "#5569FF",
            Secondary = "#6E7FFF",
            Tertiary = "#2939B3",
            Info = "#33C2FF",
            Success = "#44D600",
            Warning = "#FFA319",
            Error = "#FF1943",
            Black = "#27272F",
            Background = "#F6F6F6",
            BackgroundGrey = "#E3E5E7",
            AppbarBackground = "#FFFFFF",
            AppbarText = "#424242",
            Divider = "#E8E8E8",
            DividerLight = "#ECECEC",
            TableLines = "#E8E8E8",
            OverlayLight = "rgba(255, 255, 255, 0.7)"
        },
        PaletteDark = new Palette
        {
            Primary = "#5569FF",
            Secondary = "#6E7FFF",
            Tertiary = "#2939B3",
            Info = "#33C2FF",
            Success = "#44D600",
            Warning = "#FFA319",
            Error = "#FF1943",
            Black = "#27272F",
            Background = "#1C1C1C",
            BackgroundGrey = "#27272F",
            Surface = "#252525",
            DrawerBackground = "#090A0C",
            DrawerText = "rgba(255,255,255, 0.50)",
            AppbarBackground = "#090A0C",
            AppbarText = "rgba(255,255,255, 0.70)",
            Divider = "rgba(255, 255, 255, 0.1)",
            LinesDefault = "rgba(255, 255, 255, 0.1)",
            TableLines = "rgba(255, 255, 255, 0.1)",
            TextPrimary = "rgba(255,255,255, 0.70)",
            TextSecondary = "rgba(255,255,255, 0.50)",
            ActionDefault = "#ADADB1",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            DrawerIcon = "rgba(255,255,255, 0.50)",
            HoverOpacity = 0.2,
            OverlayDark = "rgba(33, 33, 33, 0.7)"
        },
        Typography = new Typography
        {
            H6 = new H6 { FontWeight = 400 }
        }
    };

    public ThemeService(ILocalStorageService storage) =>
        _storage = storage;

    public bool IsDarkMode { get; private set; }

    public string Icon =>
        IsDarkMode ? Icons.Outlined.LightMode : Icons.Outlined.DarkMode;

    public event Action OnChanged = () => { };

    public async Task ToggleAsync()
    {
        await _storage.SetItemAsync(StorageKey, IsDarkMode = !IsDarkMode);
        OnChanged();
    }

    public async Task InitAsync()
    {
        IsDarkMode = await _storage.GetItemAsync<bool>(StorageKey);
        OnChanged();
    }
}
