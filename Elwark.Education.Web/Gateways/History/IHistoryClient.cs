using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.History.Request;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Gateways.Models.Statistics;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.History
{
    public interface IHistoryClient
    {
        Task<ApiResponse<HistoryOverview>> GetAsync();
        
        Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync();
        
        Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period);
        
        Task<ApiResponse<PageableResponse<HistoryTopicSummary>>> GetTopicsAsync(GetTopicsRequest request);
        
        Task<ApiResponse<HistoryTopicDetail>> GetTopicAsync(string topicId);
        
        Task<ApiResponse<HistoryArticleDetail>> GetArticleAsync(string articleId);
        
        Task<ApiResponse<TestCreatedResult>> CreateTestForArticleAsync(string articleId);
        
        Task<ApiResponse<HistoryTestModel>> GetTestAsync(string testId);
        
        Task<ApiResponse<ManyAnswersResult>> CheckAnswer(string testId, string questionId, ManyAnswer answer);

        Task<ApiResponse<SingleAnswerResult>> CheckAnswer(string testId, string questionId, SingleAnswer answer);

        Task<ApiResponse<TextAnswerResult>> CheckAnswer(string testId, string questionId, TextAnswer answer);

        public Task<ApiResponse<ContentStatistics>> GetMyStatisticsAsync();
        
        Task<ApiResponse<PageableResponse<TestConclusionSummary>>> GetMyTestConclusionsAsync(PageableRequest request);
        
        Task<ApiResponse<TestConclusionDetail>> GetMyTestConclusionAsync(string testId);
    }
}