using System.Threading.Tasks;
using Elwark.Education.Web.Services.History.Model;
using Elwark.Education.Web.Services.History.Request;
using Elwark.Education.Web.Services.Model;

namespace Elwark.Education.Web.Services.History
{
    public interface IHistoryService
    {
        Task<ApiResponse<HistoryAggregate>> GetAsync();
        
        Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync();
        
        Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(PeriodType type);
        
        Task<ApiResponse<HistoryTopicItem[]>> GetTopicsAsync(GetTopicsRequest request);
        
        Task<ApiResponse<HistoryTopicModel>> GetTopicAsync(string topicId);
        
        Task<ApiResponse<HistoryArticleModel>> GetArticleAsync(string articleId);
        
        Task<ApiResponse<TestCreatedResult>> CreateTestForArticleAsync(string articleId);
        
        Task<ApiResponse<HistoryTestModel>> GetTestAsync(string testId);
        
        Task<ApiResponse<ManyAnswersResult>> CheckTestAnswer(string testId, string questionId, ManyAnswer answer);

        Task<ApiResponse<SingleAnswerResult>> CheckTestAnswer(string testId, string questionId, SingleAnswer answer);

        Task<ApiResponse<TextAnswerResult>> CheckTestAnswer(string testId, string questionId, TextAnswer answer);
    }
}