using Education.Web.Services.Api;

namespace Education.Web.Services.History.Topic.Request;

public sealed record GetTopicsRequest(EpochType Epoch, int Page, int Count)
    : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>
        {
            [nameof(Epoch)] = Epoch.ToFastString(),
            [nameof(Page)] = Page.ToString(),
            [nameof(Count)] = Count.ToString()
        };

        return QueryString.Create(values);
    }
}
