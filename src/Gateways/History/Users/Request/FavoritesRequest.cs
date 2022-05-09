using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Users.Request;

public sealed record FavoritesRequest(FavoritesRequest.SortType Sort, string? Token, int Count)
    : IQueryStringRequest
{
    public enum SortType
    {
        DateAddedNewest = 0,
        DateAddedOldest = 1
    }

    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>(3)
        {
            [nameof(Sort)] = Sort switch
            {
                SortType.DateAddedNewest => nameof(SortType.DateAddedNewest),
                SortType.DateAddedOldest => nameof(SortType.DateAddedOldest),
                _ => throw new ArgumentOutOfRangeException()
            },
            [nameof(Count)] = Count.ToString()
        };
        
        if(Token is not null)
            values.Add(nameof(Token), Token);
        
        return QueryString.Create(values);
    }
}
