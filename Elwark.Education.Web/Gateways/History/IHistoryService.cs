using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.History.Request;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.History
{
    public interface IHistoryService
    {
        Task<ApiResponse<HistoryAggregate>> GetAsync();
        
        Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync();
        
        Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period);
        
        Task<ApiResponse<PageableResponse<HistoryTopicItem>>> GetTopicsAsync(GetTopicsRequest request);
        
        Task<ApiResponse<HistoryTopicModel>> GetTopicAsync(string topicId);
        
        Task<ApiResponse<HistoryArticleModel>> GetArticleAsync(string articleId);
        
        Task<ApiResponse<TestCreatedResult>> CreateTestForArticleAsync(string articleId);
        
        Task<ApiResponse<HistoryTestModel>> GetTestAsync(string testId);
        
        Task<ApiResponse<ManyAnswersResult>> CheckTestAnswer(string testId, string questionId, ManyAnswer answer);

        Task<ApiResponse<SingleAnswerResult>> CheckTestAnswer(string testId, string questionId, SingleAnswer answer);

        Task<ApiResponse<TextAnswerResult>> CheckTestAnswer(string testId, string questionId, TextAnswer answer);

        Task<ApiResponse<PageableResponse<TestConclusion>>> GetTestConclusionsAsync(PageableRequest request);
    }
}