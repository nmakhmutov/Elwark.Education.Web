using Elwark.Education.Web.Gateways.Models.History;

namespace Elwark.Education.Web.Gateways.History.Request
{
    public sealed record GetTopicsRequest(HistoryPeriodType Period, string? Token, short Count)
        : PageRequest(Token, Count);
}
