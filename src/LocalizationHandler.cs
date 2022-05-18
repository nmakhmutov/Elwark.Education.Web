using System.Globalization;
using System.Net.Http.Headers;

namespace Education.Web;

public sealed class LocalizationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.AcceptLanguage
            .Add(new StringWithQualityHeaderValue(CultureInfo.CurrentCulture.TwoLetterISOLanguageName));

        return base.SendAsync(request, ct);
    }
}
