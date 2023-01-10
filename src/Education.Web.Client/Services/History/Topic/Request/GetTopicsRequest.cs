using Education.Web.Client.Services.Api;

namespace Education.Web.Client.Services.History.Topic.Request;

public sealed record GetTopicsRequest(EpochType Epoch, int Offset, int Limit)
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
