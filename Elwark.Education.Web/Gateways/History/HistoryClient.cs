using System;
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
        }

        public Task<ApiResponse<HistoryOverview>> GetAsync() =>
            ExecuteAsync<HistoryOverview>(() => _client.GetAsync("history"));

        public Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync() =>
            ExecuteAsync<HistoryPeriodModel[]>(() => _client.GetAsync("history/periods"));

        public Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period) =>
            ExecuteAsync<HistoryPeriodModel>(() => _client.GetAsync($"history/periods/{period}"));

        public Task<ApiResponse<PageableResponse<TopicSummary>>> GetTopicsAsync(GetTopicsRequest request) =>
            ExecuteAsync<PageableResponse<TopicSummary>>(() =>
                _client.GetAsync($"history/periods/{request.Type}/topics?token={request.Token}&count={request.Count}"));

        public Task<ApiResponse<bool>> ToggleFavoriteAsync(string topicId) =>
            ExecuteAsync<bool>(() => _client.PostAsync($"history/topics/{topicId}/favorite", EmptyContent));

        public Task<ApiResponse<HistoryTopicDetail>> GetTopicAsync(string topicId) =>
            ExecuteAsync<HistoryTopicDetail>(() => _client.GetAsync($"history/topics/{topicId}"));

        public Task<ApiResponse<HistoryArticleDetail>> GetArticleAsync(string articleId) =>
            ExecuteAsync<HistoryArticleDetail>(() => _client.GetAsync($"history/articles/{articleId}"));

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

        public Task<ApiResponse<ContentStatistics>> GetMyStatisticsAsync() =>
            ExecuteAsync<ContentStatistics>(() => _client.GetAsync("history/me/statistics"));

        public Task<ApiResponse<PageableResponse<TestConclusionSummary>>> GetMyTestConclusionsAsync(
            PageableRequest request) =>
            ExecuteAsync<PageableResponse<TestConclusionSummary>>(() =>
                _client.GetAsync($"history/me/test-conclusions?token={request.Token}&count={request.Count}"));

        public Task<ApiResponse<TestConclusionDetail>> GetMyTestConclusionAsync(string testId) =>
            ExecuteAsync<TestConclusionDetail>(() => _client.GetAsync($"history/me/test-conclusions/{testId}"));
    }
}
