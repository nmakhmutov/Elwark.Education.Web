using Elwark.Education.Web.Gateways.Models.History;

namespace Elwark.Education.Web.Gateways.History.Request
{
    public sealed record GetTopicsRequest(HistoryPeriodType Type, string? Token, short Count)
        : PageableRequest(Token, Count);
}