using System.Threading.Tasks;

namespace Elwark.Education.Web.Infrastructure.LanguageStorage
{
    public interface ILanguageStorage
    {
        ValueTask SetAsync(string language);
    }
}
