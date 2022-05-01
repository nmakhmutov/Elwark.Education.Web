using Education.Web.Gateways.History.Empires.Model;
using Education.Web.Gateways.History.Empires.Request;
using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Empires;

internal sealed class EmpireClient : GatewayClient
{
    private readonly HttpClient _client;

    public EmpireClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<PageResponse<EmpireOverview>>> GetAsync(GetEmpiresRequest request)
    {
        var url = $"history/empires{request.ToQueryString()}";
        return ExecuteAsync<PageResponse<EmpireOverview>>(ct => _client.GetAsync(url, ct));
    }
}
