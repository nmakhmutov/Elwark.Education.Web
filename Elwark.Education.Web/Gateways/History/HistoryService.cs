using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.History.Request;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;
using Elwark.Education.Web.Infrastructure;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.History
{
    internal sealed class HistoryService : GatewayClient, IHistoryService
    {
        private readonly HttpClient _client;

        public HistoryService(HttpClient client)
        {
            _client = client;
        }

        public Task<ApiResponse<HistoryAggregate>> GetAsync() =>
            ExecuteAsync<HistoryAggregate>(() => _client.GetAsync("history"));

        public Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync() =>
            ExecuteAsync<HistoryPeriodModel[]>(() => _client.GetAsync("history/periods"));

        public Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period) =>
            ExecuteAsync<HistoryPeriodModel>(() => _client.GetAsync($"history/periods/{period}"));

        public Task<ApiResponse<PageableResponse<HistoryTopicItem>>> GetTopicsAsync(GetTopicsRequest request) =>
            ExecuteAsync<PageableResponse<HistoryTopicItem>>(() =>
                _client.GetAsync($"history/periods/{request.Type}/topics?token={request.Token}&count={request.Count}"));

        public Task<ApiResponse<HistoryTopicModel>> GetTopicAsync(string topicId) =>
            ExecuteAsync<HistoryTopicModel>(() => _client.GetAsync($"history/topics/{topicId}"));

        public Task<ApiResponse<HistoryArticleModel>> GetArticleAsync(string articleId) =>
            ExecuteAsync<HistoryArticleModel>(() => _client.GetAsync($"history/articles/{articleId}"));

        public Task<ApiResponse<TestCreatedResult>> CreateTestForArticleAsync(string articleId) =>
            ExecuteAsync<TestCreatedResult>(() =>
                _client.PostAsync($"history/articles/{articleId}/test", EmptyContent));

        public Task<ApiResponse<HistoryTestModel>> GetTestAsync(string testId) =>
            ExecuteAsync<HistoryTestModel>(() => _client.GetAsync($"history/tests/{testId}"));

        public Task<ApiResponse<ManyAnswersResult>> CheckAnswer(string testId, string questionId, ManyAnswer answer) =>
            ExecuteAsync<ManyAnswersResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

        public Task<ApiResponse<SingleAnswerResult>>
            CheckAnswer(string testId, string questionId, SingleAnswer answer) =>
            ExecuteAsync<SingleAnswerResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

        public Task<ApiResponse<TextAnswerResult>> CheckAnswer(string testId, string questionId, TextAnswer answer) =>
            ExecuteAsync<TextAnswerResult>(() =>
                _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

        public Task<ApiResponse<PageableResponse<TestConclusion>>> GetTestConclusionsAsync(PageableRequest request) =>
            ExecuteAsync<PageableResponse<TestConclusion>>(() =>
                _client.GetAsync($"history/me/test-conclusions?token={request.Token}&count={request.Count}"));
    }
}