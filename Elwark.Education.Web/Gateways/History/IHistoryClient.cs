using System;
using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.History.Request;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Gateways.Models.Statistics;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

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
