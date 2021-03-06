using System;
using System.Globalization;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MudBlazor;
using MudBlazor.Utilities;

namespace Education.Client.Infrastructure.Services
{
    public sealed class TopicContentFormatService
    {
        private const double MinTextSize = 1;
        private const double MaxTextSize = 2;
        private const string StorageKey = "tcfs";

        private readonly ILocalStorageService _storage;

        public TopicContentFormatService(ILocalStorageService storage)
        {
            _storage = storage;
            TextAlign = Align.Left;
            FontSize = MinTextSize;
            Width = Width.False;
            TextStyles = string.Empty;
            WidthStyles = string.Empty;
            UpdateStyles();
        }

        public Align TextAlign { get; private set; }

        public double FontSize { get; private set; }

        public Width Width { get; private set; }

        public string TextStyles { get; private set; }

        public string WidthStyles { get; private set; }

        public event Action OnChange = () => { };

        public bool CanIncreaseFontSize() => FontSize < MaxTextSize;

        public async Task IncreaseFontSizeAsync()
        {
            if (!CanIncreaseFontSize())
                return;

            FontSize += 0.1;

            await Update();
        }

        public bool CanDecreaseFontSize() => FontSize > MinTextSize;

        public async Task DecreaseFontSizeAsync()
        {
            if (!CanDecreaseFontSize())
                return;

            FontSize -= 0.1;
            await Update();
        }

        public Task AlignTextLeftAsync()
        {
            TextAlign = Align.Left;
            return Update();
        }

        public Task AlignTextRightAsync()
        {
            TextAlign = Align.Right;
            return Update();
        }

        public Task AlignTextCenterAsync()
        {
            TextAlign = Align.Center;
            return Update();
        }

        public Task AlignTextJustifyAsync()
        {
            TextAlign = Align.Justify;
            return Update();
        }

        public Task SetWidthMdAsync()
        {
            Width = Width.md;
            return Update();
        }

        public Task SetWidthLgAsync()
        {
            Width = Width.lg;
            return Update();
        }

        public Task SetWidthFalseAsync()
        {
            Width = Width.False;
            return Update();
        }

        public async ValueTask InitAsync()
        {
            var result = await _storage.GetItemAsync<State>(StorageKey);
            if (result is null)
                return;

            TextAlign = result.TextAlign;
            Width = result.Width;
            FontSize = result.FontSize switch
            {
                < MinTextSize => MinTextSize,
                > MaxTextSize => MaxTextSize,
                _ => result.FontSize
            };

            UpdateStyles();
        }

        private ValueTask SaveStateAsync() =>
            _storage.SetItemAsync(StorageKey, new State(TextAlign, Math.Round(FontSize, 2), Width));

        private void UpdateStyles()
        {
            TextStyles = StyleBuilder.Empty()
                .AddStyle("font-size", FontSize.ToString("0.0", CultureInfo.InvariantCulture) + "rem")
                .AddStyle("text-align", TextAlign.ToString().ToLowerInvariant())
                .Build();

            WidthStyles = StyleBuilder.Empty()
                .AddStyle("margin", "0 auto")
                .AddStyle("max-width", Width switch
                {
                    Width.md => "960px",
                    Width.lg => "1280px",
                    _ => "100%"
                })
                .Build();
        }

        private async Task Update()
        {
            UpdateStyles();
            OnChange();
            await SaveStateAsync();
        }
        
        private record State(Align TextAlign, double FontSize, Width Width);
    }
}
