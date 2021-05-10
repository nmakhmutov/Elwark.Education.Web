using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.History.Request;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Gateways.Models.Statistics;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.History
{
    internal sealed class HistoryClient : GatewayClient, IHistoryClient
    {
        private readonly HttpClient _client;

        public HistoryClient(HttpClient client)
        {
            _client = client;
            Topic = new HistoryTopicClient(client);
            Test = new HistoryTestClient(client);
            User = new HistoryUserClient(client);
        }

        public Task<ApiResponse<HistoryOverview>> GetAsync() =>
            ExecuteAsync<HistoryOverview>(() => _client.GetAsync("history"));

        public Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync() =>
            ExecuteAsync<HistoryPeriodModel[]>(() => _client.GetAsync("history/periods"));

        public Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period) =>
            ExecuteAsync<HistoryPeriodModel>(() => _client.GetAsync($"history/periods/{period}"));

        public HistoryTopicClient Topic { get; }

        public HistoryTestClient Test { get; }

        public HistoryUserClient User { get; }
    }

    internal sealed class HistoryUserClient : GatewayClient
    {
        private readonly HttpClient _client;

        public HistoryUserClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<HistoryUserProfile>> GetOverviewAsync() =>
            ExecuteAsync<HistoryUserProfile>(() => _client.GetAsync("history/me"));
        
        public Task<ApiResponse<UserStatistics>> GetStatisticsAsync() =>
            ExecuteAsync<UserStatistics>(() => _client.GetAsync("history/me/statistics"));

        public Task<ApiResponse<PageResponse<TestConclusionSummary>>> GetTestConclusionsAsync(PageRequest request) =>
            ExecuteAsync<PageResponse<TestConclusionSummary>>(() =>
                _client.GetAsync($"history/me/test-conclusions?token={request.Token}&count={request.Count}"));

        public Task<ApiResponse<TestConclusionDetail>> GetTestConclusionAsync(string testId) =>
            ExecuteAsync<TestConclusionDetail>(() => _client.GetAsync($"history/me/test-conclusions/{testId}"));

        public Task<ApiResponse<PageResponse<TopicSummary>>> GetFavoritesAsync(PageRequest request) =>
            ExecuteAsync<PageResponse<TopicSummary>>(() =>
                _client.GetAsync($"history/me/favorites?token={request.Token}&count={request.Count}"));
    }

    internal sealed class HistoryTestClient : GatewayClient
    {
        private readonly HttpClient _client;

        public HistoryTestClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<HistoryTestModel>> GetAsync(string id) =>
            ExecuteAsync<HistoryTestModel>(() => _client.GetAsync($"history/tests/{id}"));

        public Task<ApiResponse<ManyAnswersResult>> CheckAsync(string testId, string questionId, ManyAnswer answer) =>
            ExecuteAsync<ManyAnswersResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

        public Task<ApiResponse<SingleAnswerResult>>
            CheckAsync(string testId, string questionId, SingleAnswer answer) =>
            ExecuteAsync<SingleAnswerResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

        public Task<ApiResponse<TextAnswerResult>> CheckAsync(string testId, string questionId, TextAnswer answer) =>
            ExecuteAsync<TextAnswerResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));
    }

    internal sealed class HistoryTopicClient : GatewayClient
    {
        private readonly HttpClient _client;

        public HistoryTopicClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<PageResponse<TopicSummary>>> GetAsync(GetTopicsRequest request) =>
            ExecuteAsync<PageResponse<TopicSummary>>(() =>
                _client.GetAsync($"history/topics?period={request.Period}&count={request.Count}&token={request.Token}")
            );

        public Task<ApiResponse<HistoryTopicDetail>> GetAsync(string id) =>
            ExecuteAsync<HistoryTopicDetail>(() => _client.GetAsync($"history/topics/{id}"));

        public Task<ApiResponse<RandomTopic>> GetRandomAsync() =>
            ExecuteAsync<RandomTopic>(() => _client.GetAsync("history/topics/random"));

        public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
            ExecuteAsync<bool>(() => _client.PostAsync($"history/topics/{id}/favorite", EmptyContent));

        public Task<ApiResponse<Unit>> LikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/like", EmptyContent));

        public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/dislike", EmptyContent));

        public Task<ApiResponse<TestCreatedResult>> CreateTestAsync(string id, TestDifficulty difficulty) =>
            ExecuteAsync<TestCreatedResult>(() =>
                _client.PostAsync($"history/topics/{id}/test?difficulty={difficulty}", EmptyContent));
    }
}
