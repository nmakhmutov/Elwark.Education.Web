using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models.History;

namespace Elwark.Education.Web.Gateways.History
{
    internal interface IHistoryClient
    {
        Task<ApiResponse<HistoryOverview>> GetAsync();

        Task<ApiResponse<HistoryEpochModel[]>> GetEpochsAsync();

        Task<ApiResponse<HistoryEpochModel>> GetEpochAsync(EpochType epoch);

        HistoryTopicClient Topic { get; }

        HistoryTestClient Test { get; }

        HistoryUserClient User { get; }
    }
}
