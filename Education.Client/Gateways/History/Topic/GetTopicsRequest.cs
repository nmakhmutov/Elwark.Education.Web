using Education.Client.Gateways.History.Epoch;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Topic
{
    public sealed record GetTopicsRequest(EpochType Epoch, int Page, short Count) 
        : PageRequest(Page, Count);
}
