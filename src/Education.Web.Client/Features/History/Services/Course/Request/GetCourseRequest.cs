using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Course.Request;

public sealed record GetCourseRequest(int Offset, int Limit) : IQueryStringRequest
{
    public QueryString ToQueryString() =>
        QueryString.Create(new Dictionary<string, string?>
        {
            [nameof(Limit)] = Limit.ToString(),
            [nameof(Offset)] = Offset.ToString()
        });
}
