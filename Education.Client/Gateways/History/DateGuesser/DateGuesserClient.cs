using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.History.DateGuesser
{
    internal sealed class DateGuesserClient : GatewayClient
    {
        private readonly HttpClient _client;

        public DateGuesserClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<DateGuesserTestModel>> GetAsync() =>
            ExecuteAsync<DateGuesserTestModel>(() => _client.GetAsync("history/date-guesser"));

        public Task<ApiResponse<DateGuesserConclusionModel>> ConcludeAsync() =>
            ExecuteAsync<DateGuesserConclusionModel>(() => _client.GetAsync("history/date-guesser/conclusion"));

        public Task<ApiResponse<DateGuesserTestModel>> CreateAsync(DateGuesserCreateRequest request) =>
            ExecuteAsync<DateGuesserTestModel>(() => _client.PostAsync("history/date-guesser", ToJson(request)));

        public Task<ApiResponse<DateGuesserCheckModel>> CheckAsync(DateGuesserCheckRequest request) =>
            ExecuteAsync<DateGuesserCheckModel>(() => _client.PutAsync("history/date-guesser", ToJson(request)));
    }
    
    public sealed record DateGuesserCreateRequest(int Questions, EpochType Epoch);

    public sealed record DateGuesserCheckRequest(string Id, int Year, uint? Month, uint? Day);
}
