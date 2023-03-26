using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Article.Request;

public sealed record GetArticlesRequest(EpochType Epoch, GetArticlesRequest.SortType Sort, int Offset, int Limit)
    : IQueryStringRequest
{
    public enum SortType
    {
        Newest = 0,
        Popularity = 1,
        Trending = 2
    }

    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Epoch)] = Epoch.ToFastString(),
            [nameof(Sort)] = Sort switch
            {
                SortType.Newest => nameof(SortType.Newest),
                SortType.Popularity => nameof(SortType.Popularity),
                SortType.Trending => nameof(SortType.Trending),
                _ => nameof(SortType.Newest)
            },
            [nameof(Limit)] = Limit.ToString(),
            [nameof(Offset)] = Offset.ToString()
        };

        return QueryString.Create(values);
    }
}
