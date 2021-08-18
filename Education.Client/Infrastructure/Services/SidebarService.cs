using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Education.Client.Infrastructure.Services
{
    public sealed class SidebarService
    {
        private const string StorageKey = "sbs";
        private readonly ILocalStorageService _storage;

        public bool IsOpen { get; private set; }
        
        public SidebarService(ILocalStorageService storage) =>
            _storage = storage;

        public async Task InitAsync()
        {
            IsOpen = await _storage.GetItemAsync<bool>(StorageKey);
        }
        
        public async Task ToggleAsync()
        {
            IsOpen = !IsOpen;
            await _storage.SetItemAsync(StorageKey, IsOpen);
        }

        public async Task SetAsync(bool value)
        {
            IsOpen = value;
            await _storage.SetItemAsync(StorageKey, IsOpen);
        }
    }
}
