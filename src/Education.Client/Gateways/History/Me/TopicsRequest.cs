using System.Collections.Generic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public sealed record TopicsRequest(bool OnlyFavorite, TopicsRequest.SortType Sort, int Page, short Count)
    : PageRequest(Page, Count)
{
    public enum SortType
    {
        DateAddedNewest = 0,
        DateAddedOldest = 1
    }

    public override string ToQuery() =>
        QueryString.Create(
                new Dictionary<string, string?>
                {
                    { nameof(Sort), Sort.ToString() },
                    { nameof(OnlyFavorite), OnlyFavorite.ToString() },
                    { nameof(Page), Page.ToString() },
                    { nameof(Count), Count.ToString() }
                }
            )
            .ToString();
}
