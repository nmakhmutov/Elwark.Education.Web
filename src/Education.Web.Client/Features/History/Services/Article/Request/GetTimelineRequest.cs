using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Article.Request;

public sealed record GetTimelineRequest(int Year, int Offset, int Limit) : IQueryStringRequest
{
    public QueryString ToQueryString() =>
        QueryString.Create(new Dictionary<string, string?>
        {
            [nameof(Year)] = Year.ToString(),
            [nameof(Offset)] = Offset.ToString(),
            [nameof(Limit)] = Limit.ToString()
        });
}
