using System.Globalization;

namespace Education.Web;

public sealed class LocalizationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.AcceptLanguage.Clear();
        request.Headers.AcceptLanguage.ParseAdd(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        
        return base.SendAsync(request, ct);
    }
}
