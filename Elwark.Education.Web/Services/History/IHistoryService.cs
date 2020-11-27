using System.Threading.Tasks;
using Elwark.Education.Web.Services.History.Model;
using Elwark.Education.Web.Services.History.Request;
using Elwark.Education.Web.Services.Model;

namespace Elwark.Education.Web.Services.History
{
    public interface IHistoryService
    {
        Task<HistoryArticleItem[]> GetRandomArticlesAsync();
        Task<HistoryPeriodModel[]> GetPeriodsAsync();
        Task<HistoryPeriodModel?> GetPeriodAsync(PeriodType type);
        Task<HistoryTopicItem[]> GetTopicsAsync(GetTopicsRequest request);
        Task<HistoryTopicModel?> GetTopicAsync(string topicId);
        Task<HistoryArticleModel?> GetArticleAsync(string articleId);
        Task<TestCreatedResult?> CreateTestForArticleAsync(string articleId);
        Task<HistoryTestModel?> GetTestAsync(string testId);
        Task<TestAnswerResult> CheckTestAnswer(string testId, string questionId, TestAnswer answer);
    }
}