using Education.Web.Client.Clients;

namespace Education.Web.Client.Features.History.Clients.Course.Request;

public sealed record GetCourseRequest(GetCourseRequest.SortType Sort, int Offset, int Limit) : IQueryStringRequest
{
    public enum SortType
    {
        Newest = 0,
        Popularity = 1,
        Trending = 2
    }

    public QueryString ToQueryString() =>
        QueryString.Create(new Dictionary<string, string?>
        {
            [nameof(Sort)] = Sort switch
            {
                SortType.Newest => nameof(SortType.Newest),
                SortType.Popularity => nameof(SortType.Popularity),
                SortType.Trending => nameof(SortType.Trending),
                _ => nameof(SortType.Newest)
            },
            [nameof(Offset)] = Offset.ToString(),
            [nameof(Limit)] = Limit.ToString()
        });
}
