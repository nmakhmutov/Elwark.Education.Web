using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Client;

public class LocalizationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.Add("Language", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        return base.SendAsync(request, ct);
    }
}
