using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MudBlazor;

namespace Education.Client;

public sealed class ThemeProvider
{
    public enum ThemeType
    {
        Light,
        Dark
    }

    private const string StorageKey = "ts";

    private static readonly MudTheme LightTheme = new()
    {
        Palette = new Palette
        {
            Primary = "#5569ff",
            Secondary = "#584bb0",
            Tertiary = "#8560c7",
            Info = "#33c2ff",
            Success = "#44d600",
            Warning = "#ffa319",
            Error = "#ff1943",
            Black = "#272c34",
            Background = "#f6f8fb",
            BackgroundGrey = "#e3e5e7",
            AppbarBackground = Colors.Shades.White, //"#3949ab"
            AppbarText = Colors.Grey.Darken3, //"#27272f"
            Divider = "rgba(34, 51, 84, 0.1)",
            TableLines = "rgba(34, 51, 84, 0.1)",
            OverlayLight = "rgba(255, 255, 255, 0.7)"
        }
    };

    private static readonly MudTheme DarkTheme = new()
    {
        Palette = new Palette
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

    private readonly ILocalStorageService _storage;

    public ThemeProvider(ILocalStorageService storage)
    {
        _storage = storage;
        Type = ThemeType.Light;
    }

    public ThemeType Type { get; private set; }

    public MudTheme Theme => Type switch
    {
        ThemeType.Light => LightTheme,
        ThemeType.Dark => DarkTheme,
        _ => throw new ArgumentOutOfRangeException()
    };

    public string Icon => Type switch
    {
        ThemeType.Light => Icons.Outlined.LightMode,
        ThemeType.Dark => Icons.Outlined.DarkMode,
        _ => throw new ArgumentOutOfRangeException()
    };

    public event Action OnChange = () => { };

    public async Task ToggleAsync()
    {
        Type = Type == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark;
        await _storage.SetItemAsync(StorageKey, Type);
        OnChange();
    }

    public async Task InitAsync()
    {
        Type = await _storage.GetItemAsync<ThemeType>(StorageKey);
        OnChange();
    }
}
