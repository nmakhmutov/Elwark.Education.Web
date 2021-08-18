using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MudBlazor;

namespace Education.Client.Infrastructure.Services
{
    public sealed class ThemeService
    {
        private const string StorageKey = "ts";

        private readonly MudTheme _darkTheme = new()
        {
            Palette = new Palette
            {
                Primary = "#5569ff",
                Secondary = "#8560c7",
                Tertiary = "#584bb0",
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
                HoverOpacity = 0.6
            }
        };

        private readonly MudTheme _lightTheme = new()
        {
            Palette = new Palette
            {
                Primary = "#5569ff",
                Secondary = "#8560c7",
                Tertiary = "#584bb0",
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
                TableLines = "rgba(34, 51, 84, 0.1)"
            }
        };

        private readonly ILocalStorageService _storage;
        private Theme _theme;

        public ThemeService(ILocalStorageService storage)
        {
            _storage = storage;
            _theme = Theme.Light;
        }

        public MudTheme Current => _theme switch
        {
            Theme.Light => _lightTheme,
            Theme.Dark => _darkTheme,
            _ => throw new ArgumentOutOfRangeException()
        };

        public string Icon => _theme switch
        {
            Theme.Light => Icons.Filled.Brightness7,
            Theme.Dark => Icons.Filled.Brightness3,
            _ => throw new ArgumentOutOfRangeException()
        };

        public async Task ToggleAsync()
        {
            _theme = _theme == Theme.Dark ? Theme.Light : Theme.Dark;
            await _storage.SetItemAsync(StorageKey, _theme);
        }

        public async Task InitAsync() =>
            _theme = await _storage.GetItemAsync<Theme>(StorageKey);

        private enum Theme
        {
            Light,
            Dark
        }
    }
}
