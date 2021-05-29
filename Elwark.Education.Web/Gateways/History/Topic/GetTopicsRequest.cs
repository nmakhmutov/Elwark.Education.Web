using Elwark.Education.Web.Gateways.History.Epoch;
using Elwark.Education.Web.Gateways.Models;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    public sealed record GetTopicsRequest(EpochType Epoch, string? Token, short Count) 
        : PageRequest(Token, Count);
}
