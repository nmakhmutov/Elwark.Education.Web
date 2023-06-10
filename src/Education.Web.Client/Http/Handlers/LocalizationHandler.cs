namespace Education.Web.Client.Http.Handlers;

internal sealed class LocalizationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.AcceptLanguage.Clear();
        request.Headers.AcceptLanguage.ParseAdd("en");

        return base.SendAsync(request, ct);
    }
}