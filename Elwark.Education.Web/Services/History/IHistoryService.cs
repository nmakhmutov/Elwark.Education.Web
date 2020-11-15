using System.Collections.Generic;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.History.Models;
using Elwark.Education.Web.Services.History.Requests;

namespace Elwark.Education.Web.Services.History
{
    public interface IHistoryService
    {
        Task<IReadOnlyCollection<HistoryArticleItem>> GetRandomArticlesAsync();
        Task<IReadOnlyCollection<HistoryPeriodModel>> GetPeriodsAsync();
        Task<HistoryPeriodModel?> GetPeriodAsync(PeriodType type);
        Task<IReadOnlyCollection<HistoryTopicItem>> GetTopicsAsync(GetTopicsRequest request);
        Task<HistoryTopicModel?> GetTopicAsync(string topicId);
    }
}