using System.Threading.Tasks;

namespace Elwark.Education.Web.Infrastructure.LocalStorage
{
    public interface ILocalStorage
    {
        ValueTask SetLanguageAsync(string language);
        
        ValueTask<bool> GetMainDrawerState();
        
        ValueTask SetMainDrawerState(bool isOpen);
    }
}