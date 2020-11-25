using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Elwark.Education.Web
{
    public class LocalizationMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("Language", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return base.SendAsync(request, cancellationToken);
        }
    }
}