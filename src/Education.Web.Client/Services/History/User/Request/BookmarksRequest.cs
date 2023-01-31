using Education.Http;

namespace Education.Web.Client.Services.History.User.Request;

public sealed record BookmarksRequest(BookmarksRequest.SortType Sort, int Count, string? Token = null)
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
            [nameof(Sort)] = SortTypes[Sort],
            [nameof(Count)] = Count.ToString()
        };

        if (Token is not null)
            values.Add(nameof(Token), Token);

        return QueryString.Create(values);
    }
}
