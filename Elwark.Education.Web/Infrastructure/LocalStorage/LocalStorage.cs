using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Elwark.Education.Web.Infrastructure.LocalStorage
{
    public class LocalStorage:ILocalStorage
    {
        private readonly ILocalStorageService _storage;

        public LocalStorage(ILocalStorageService storage) =>
            _storage = storage;

        public ValueTask SetLanguageAsync(string language) =>
            _storage.SetItemAsync("language", language);

        public ValueTask<bool> GetMainDrawerState() =>
            _storage.GetItemAsync<bool>("main_drawer_is_open");

        public ValueTask SetMainDrawerState(bool isOpen) =>
            _storage.SetItemAsync("main_drawer_is_open", isOpen);
    }
}