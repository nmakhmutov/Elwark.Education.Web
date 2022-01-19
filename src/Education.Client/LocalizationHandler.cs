using System.Globalization;

namespace Education.Client;

public sealed class LocalizationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.Add("Language", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        return base.SendAsync(request, ct);
    }
}
