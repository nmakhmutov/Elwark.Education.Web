using System.Net.Http;
using System.Threading.Tasks;

namespace Elwark.Education.Web.Gateways.History.Epoch
{
    internal sealed class EpochClient : GatewayClient
    {
        private readonly HttpClient _client;

        public EpochClient(HttpClient client) =>
            _client = client;
        
        public Task<ApiResponse<EpochModel[]>> GetAsync() =>
            ExecuteAsync<EpochModel[]>(() => _client.GetAsync("history/epochs"));

        public Task<ApiResponse<EpochModel>> GetAsync(EpochType epoch) =>
            ExecuteAsync<EpochModel>(() => _client.GetAsync($"history/epochs/{epoch}"));
    }
}
