using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.History.Model;
using Elwark.Education.Web.Services.History.Request;

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
            var response = await _client.GetFromJsonAsync<IReadOnlyCollection<HistoryPeriodModel>>(
                "history/periods", Json.Options);

            return response ?? Array.Empty<HistoryPeriodModel>();
        }

        public async Task<HistoryPeriodModel?> GetPeriodAsync(PeriodType type)
        {
            return await _client.GetFromJsonAsync<HistoryPeriodModel>($"history/periods/{type}", Json.Options);
        }

        public async Task<IReadOnlyCollection<HistoryTopicItem>> GetTopicsAsync(GetTopicsRequest request)
        {
            var (periodType, page, count) = request;

            return await _client.GetFromJsonAsync<IReadOnlyCollection<HistoryTopicItem>>(
                       $"history/periods/{periodType}/topics?page={page}&count={count}", Json.Options
                   )
                   ?? Array.Empty<HistoryTopicItem>();
        }

        public async Task<HistoryTopicModel?> GetTopicAsync(string topicId)
        {
            return await _client.GetFromJsonAsync<HistoryTopicModel>($"history/topics/{topicId}", Json.Options);
        }

        public async Task<HistoryArticleModel?> GetArticleAsync(string articleId)
        {
            return await _client.GetFromJsonAsync<HistoryArticleModel>($"history/articles/{articleId}", Json.Options);
        }

        public async Task<IReadOnlyCollection<HistoryArticleItem>> GetRandomArticlesAsync()
        {
            var response = await _client.GetFromJsonAsync<IReadOnlyCollection<HistoryArticleItem>>(
                "history/articles/random", Json.Options);

            return response ?? Array.Empty<HistoryArticleItem>();
        }
    }
}