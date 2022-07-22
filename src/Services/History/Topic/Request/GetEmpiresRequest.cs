using Education.Web.Services.Api;
using Education.Web.Services.Model;

namespace Education.Web.Services.History.Topic.Request;

public sealed record GetEmpiresRequest(GetEmpiresRequest.SortType Sort, int Page, int Count)
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
            [nameof(Page)] = Page.ToString(),
            [nameof(Count)] = Count.ToString()
        };

        return QueryString.Create(values);
    }
}
