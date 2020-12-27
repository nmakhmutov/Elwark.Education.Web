using System.Threading.Tasks;

namespace Elwark.Education.Web.Infrastructure.LocalStorage
{
    public interface ILocalStorage
    {
        ValueTask SetLanguageAsync(string language);
    }
}