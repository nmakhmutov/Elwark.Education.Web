using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models.History;

namespace Elwark.Education.Web.Gateways.History
{
    internal interface IHistoryClient
    {
        Task<ApiResponse<HistoryOverview>> GetAsync();

        Task<ApiResponse<HistoryPeriodModel[]>> GetPeriodsAsync();

        Task<ApiResponse<HistoryPeriodModel>> GetPeriodAsync(HistoryPeriodType period);

        HistoryTopicClient Topic { get; }

        HistoryTestClient Test { get; }

        HistoryUserClient User { get; }
    }
}
