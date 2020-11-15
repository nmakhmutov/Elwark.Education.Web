using Elwark.Education.Web.Services.History.Models;

namespace Elwark.Education.Web.Services.History.Requests
{
    public sealed record GetTopicsRequest(PeriodType Type, short Page, short Count);
}