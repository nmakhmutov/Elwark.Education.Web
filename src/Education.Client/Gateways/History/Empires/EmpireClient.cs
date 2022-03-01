using Education.Client.Gateways.History.Empires.Model;
using Education.Client.Gateways.History.Empires.Request;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Empires;

internal sealed class EmpireClient : GatewayClient
{
    private readonly HttpClient _client;

    public EmpireClient(HttpClient client) =>
        _client = client;
    
    public Task<ApiResponse<PageResponse<EmpireOverview>>> GetAsync(GetEmpiresRequest request) =>
        ExecuteAsync<PageResponse<EmpireOverview>>(ct => _client.GetAsync($"history/empires{request.ToQuery()}", ct));
}
