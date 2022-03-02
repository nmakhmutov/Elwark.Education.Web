using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Topics.Request;

public sealed record GetTopicsRequest(EpochType Epoch, int Page, int Count)
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
