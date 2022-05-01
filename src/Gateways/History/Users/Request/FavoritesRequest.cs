using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Users.Request;

public sealed record FavoritesRequest(FavoritesRequest.SortType Sort, int Page, int Count)
    : IQueryStringRequest
{
    public enum SortType
    {
        DateAddedNewest = 0,
        DateAddedOldest = 1
    }

    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Sort)] = Sort switch
            {
                SortType.DateAddedNewest => nameof(SortType.DateAddedNewest),
                SortType.DateAddedOldest => nameof(SortType.DateAddedOldest),
                _ => throw new ArgumentOutOfRangeException()
            },
            [nameof(Page)] = Page.ToString(),
            [nameof(Count)] = Count.ToString()
        };
        
        return QueryString.Create(values);
    }
}
