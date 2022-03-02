using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Users.Request;

public sealed record FavoritesRequest(FavoritesRequest.SortType Sort, int Page, int Count)
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
                    { nameof(Page), Page.ToString() },
                    { nameof(Count), Count.ToString() }
                }
            )
            .ToString();
}
