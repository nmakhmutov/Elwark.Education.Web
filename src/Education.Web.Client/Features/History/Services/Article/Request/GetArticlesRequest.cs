using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Article.Request;

public sealed record GetArticlesRequest(EpochType Epoch, int Offset, int Limit)
    : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Epoch)] = Epoch.ToFastString(),
            [nameof(Limit)] = Limit.ToString(),
            [nameof(Offset)] = Offset.ToString()
        };

        return QueryString.Create(values);
    }
}
