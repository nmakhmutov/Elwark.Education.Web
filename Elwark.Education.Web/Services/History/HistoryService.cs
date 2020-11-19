using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.History.Model;
using Elwark.Education.Web.Services.History.Request;
using Newtonsoft.Json;

namespace Elwark.Education.Web.Services.History
{
    public sealed class HistoryService : IHistoryService
    {
        private readonly HttpClient _client;

        public HistoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IReadOnlyCollection<HistoryPeriodModel>> GetPeriodsAsync()
        {
            var response = await _client.GetAsync("history/periods");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IReadOnlyCollection<HistoryPeriodModel>>(
                    await response.Content.ReadAsStringAsync()
                );

            return Array.Empty<HistoryPeriodModel>();
        }

        public async Task<HistoryPeriodModel?> GetPeriodAsync(PeriodType type)
        {
            var response = await _client.GetAsync($"history/periods/{type}");

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<HistoryPeriodModel>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<IReadOnlyCollection<HistoryTopicItem>> GetTopicsAsync(GetTopicsRequest request)
        {
            var (periodType, page, count) = request;

            var response = await _client.GetAsync($"history/periods/{periodType}/topics?page={page}&count={count}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IReadOnlyCollection<HistoryTopicItem>>(
                    await response.Content.ReadAsStringAsync()
                );

            return Array.Empty<HistoryTopicItem>();
        }

        public async Task<HistoryTopicModel?> GetTopicAsync(string topicId)
        {
            var response = await _client.GetAsync($"history/topics/{topicId}");

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<HistoryTopicModel>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<HistoryArticleModel?> GetArticleAsync(string articleId)
        {
            var response = await _client.GetAsync($"history/articles/{articleId}");

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<HistoryArticleModel>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<TestCreatedResult?> CreateTestForArticleAsync(string articleId)
        {
            var response = await _client.PostAsync($"history/articles/{articleId}/test",
                new StringContent(string.Empty, Encoding.UTF8, "application/json")
            );

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<TestCreatedResult>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<HistoryTestModel?> GetTestAsync(string testId)
        {
            var response = await _client.GetAsync($"history/tests/{testId}");

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<HistoryTestModel>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<TestAnswerResult> CheckTestAnswer(string testId, string questionId, TestAnswer answer)
        {
            var result = await _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer));

            return answer switch
            {
                ManyAnswer => await result.Content.ReadFromJsonAsync<TestManyAnswersResult>() as TestAnswerResult,
                SingleAnswer => await result.Content.ReadFromJsonAsync<TestSingleAnswerResult>() as TestAnswerResult,
                _ => null
            } ?? throw new ArgumentOutOfRangeException(nameof(answer));
        }

        public async Task<IReadOnlyCollection<HistoryArticleItem>> GetRandomArticlesAsync()
        {
            var response = await _client.GetAsync("history/articles/random");

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<IReadOnlyCollection<HistoryArticleItem>>(
                    await response.Content.ReadAsStringAsync()
                )
                : Array.Empty<HistoryArticleItem>();
        }

        private static StringContent ToJson<T>(T data) =>
            new(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    }
}