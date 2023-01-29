using Education.Web.Client.Services.Api;

namespace Education.Web.Client.Services.History.Article.Request;

public sealed record GetEmpiresRequest(GetEmpiresRequest.SortType Sort, int Offset, int Limit)
    : IQueryStringRequest
{
    public enum SortType
    {
        Area = 0,
        Population = 1,
        Duration = 2
    }

    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Sort)] = Sort switch
            {
                SortType.Area => nameof(SortType.Area),
                SortType.Population => nameof(SortType.Population),
                SortType.Duration => nameof(SortType.Duration),
                _ => nameof(SortType.Area)
            },
            [nameof(Offset)] = Offset.ToString(),
            [nameof(Limit)] = Limit.ToString()
        };

        return QueryString.Create(values);
    }
}
