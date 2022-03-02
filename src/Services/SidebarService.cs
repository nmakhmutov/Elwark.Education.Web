using Blazored.LocalStorage;

namespace Education.Web.Services;

public sealed class SidebarService
{
    private const string StorageKey = "sbs";
    private readonly ILocalStorageService _storage;

    public SidebarService(ILocalStorageService storage) =>
        _storage = storage;

    public bool IsOpen { get; private set; }

    public async Task InitAsync() =>
        IsOpen = await _storage.GetItemAsync<bool>(StorageKey);

    public async Task ToggleAsync() =>
        await _storage.SetItemAsync(StorageKey, IsOpen = !IsOpen);

    public async Task SetAsync(bool value) =>
        await _storage.SetItemAsync(StorageKey, IsOpen = value);
}
