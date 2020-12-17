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

        public async Task<ApiResponse<HistoryAggregate>> GetAsync()
        {
            var response = await _client.GetAsync("history");

            return await ToApiResponse<HistoryAggregate>(response);
        }

        public async Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync()
        {
            var response = await _client.GetAsync("history/periods");

            return await ToApiResponse<HistoryPeriodModel[]>(response);
        }

        public async Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period)
        {
            var response = await _client.GetAsync($"history/periods/{period}");

            return await ToApiResponse<HistoryPeriodModel>(response);
        }

        public async Task<ApiResponse<PageableResponse<HistoryTopicItem>>> GetTopicsAsync(GetTopicsRequest request)
        {
            var (period, token, count) = request;

            var response = await _client.GetAsync($"history/periods/{period}/topics?token={token}&count={count}");

            return await ToApiResponse<PageableResponse<HistoryTopicItem>>(response);
        }

        public async Task<ApiResponse<HistoryTopicModel>> GetTopicAsync(string topicId)
        {
            var response = await _client.GetAsync($"history/topics/{topicId}");
            
            return await ToApiResponse<HistoryTopicModel>(response);
        }

        public async Task<ApiResponse<HistoryArticleModel>> GetArticleAsync(string articleId)
        {
            var response = await _client.GetAsync($"history/articles/{articleId}");

            return await ToApiResponse<HistoryArticleModel>(response);
        }

        public async Task<ApiResponse<TestCreatedResult>> CreateTestForArticleAsync(string articleId)
        {
            var response = await _client.PostAsync($"history/articles/{articleId}/test", EmptyContent);

            return await ToApiResponse<TestCreatedResult>(response);
        }

        public async Task<ApiResponse<HistoryTestModel>> GetTestAsync(string testId)
        {
            var response = await _client.GetAsync($"history/tests/{testId}");

            return await ToApiResponse<HistoryTestModel>(response);
        }

        public async Task<ApiResponse<ManyAnswersResult>> CheckTestAnswer(string testId, string questionId,
            ManyAnswer answer)
        {
            var response = await _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer));

            return await ToApiResponse<ManyAnswersResult>(response);
        }
        
        public async Task<ApiResponse<SingleAnswerResult>> CheckTestAnswer(string testId, string questionId,
            SingleAnswer answer)
        {
            var response = await _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer));

            return await ToApiResponse<SingleAnswerResult>(response);
        }
        
        public async Task<ApiResponse<TextAnswerResult>> CheckTestAnswer(string testId, string questionId, TextAnswer answer)
        {
            var response = await _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer));

            return await ToApiResponse<TextAnswerResult>(response);
        }

        public async Task<ApiResponse<PageableResponse<TestConclusion>>> GetTestConclusionsAsync(PageableRequest request)
        {
            var (token, count) = request;

            var response = await _client.GetAsync($"history/me/test-conclusions?token={token}&count={count}");

            return await ToApiResponse<PageableResponse<TestConclusion>>(response);
        }
    }
}