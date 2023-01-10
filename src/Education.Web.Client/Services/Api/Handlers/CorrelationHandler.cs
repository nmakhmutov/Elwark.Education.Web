namespace Education.Web.Client.Services.Api.Handlers;

internal sealed class CorrelationHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var id = Guid.NewGuid().ToString("N");
        request.Headers.Add("X-Correlation-Id", id);

        return base.SendAsync(request, ct);
    }
}
