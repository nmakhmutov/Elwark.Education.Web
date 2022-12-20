using Education.Web.Services.Api;

namespace Education.Web.Services.History.User.Request;

public sealed record FavoritesRequest(FavoritesRequest.SortType Sort, int Count, string? Token = null)
    : IQueryStringRequest
{
    public enum SortType
    {
        DateAddedNewest = 0,
        DateAddedOldest = 1
    }

    public static readonly Dictionary<SortType, string> SortTypes = new(2)
    {
        [SortType.DateAddedNewest] = nameof(SortType.DateAddedNewest),
        [SortType.DateAddedOldest] = nameof(SortType.DateAddedOldest)
    };

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

        if (Token is not null)
            values.Add(nameof(Token), Token);

        return QueryString.Create(values);
    }
}
