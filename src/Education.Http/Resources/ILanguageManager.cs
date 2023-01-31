using System.Globalization;

namespace Education.Http.Resources;

internal interface ILanguageManager
{
    public string GetString(string resource);
    
    public string GetString(string resource, CultureInfo culture);

    public string GetString(string resource, CultureInfo culture, params object?[] args);
}
