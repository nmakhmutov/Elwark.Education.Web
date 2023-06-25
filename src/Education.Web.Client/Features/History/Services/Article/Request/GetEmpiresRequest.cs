using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Article.Request;

public sealed record GetEmpiresRequest(GetEmpiresRequest.SortType Sort, int Offset, int Limit)
    : IQueryStringRequest
{
    public enum SortType
    {
        Area = 0,
        Population = 1,
        Duration = 2
    }

    public QueryString ToQueryString() =>
        QueryString.Create(new Dictionary<string, string?>
        {
            [nameof(Sort)] = Sort switch
            {
                SortType.Area => nameof(SortType.Area),
                SortType.Population => nameof(SortType.Population),
                SortType.Duration => nameof(SortType.Duration),
                _ => nameof(SortType.Area)
            },
            [nameof(Limit)] = Limit.ToString(),
            [nameof(Offset)] = Offset.ToString()
        });
}
