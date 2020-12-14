using Elwark.Education.Web.Services.History.Model;

namespace Elwark.Education.Web.Services.History.Request
{
    public sealed record GetTopicsRequest(PeriodType Type, string? Token, short Count)
        : PageableRequest(Token, Count);
}