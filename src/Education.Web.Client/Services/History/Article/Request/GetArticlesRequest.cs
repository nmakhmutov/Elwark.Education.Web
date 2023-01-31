using Education.Http;

namespace Education.Web.Client.Services.History.Article.Request;

public sealed record GetArticlesRequest(EpochType Epoch, int Offset, int Limit)
    : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Epoch)] = Epoch.ToFastString(),
            [nameof(Offset)] = Offset.ToString(),
            [nameof(Limit)] = Limit.ToString()
        };

        return QueryString.Create(values);
    }
}
