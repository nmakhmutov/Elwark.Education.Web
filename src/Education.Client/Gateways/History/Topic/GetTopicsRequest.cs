using System.Collections.Generic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Topic;

public sealed record GetTopicsRequest(EpochType Epoch, int Page, short Count)
    : PageRequest(Page, Count)
{
    public override string ToQuery() =>
        QueryString.Create(
                new Dictionary<string, string?>
                {
                    { nameof(Epoch), Epoch.ToString() },
                    { nameof(Page), Page.ToString() },
                    { nameof(Count), Count.ToString() }
                }
            )
            .ToString();
}
