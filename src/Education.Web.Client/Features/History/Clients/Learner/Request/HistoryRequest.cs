using Education.Web.Client.Clients;

namespace Education.Web.Client.Features.History.Clients.Learner.Request;

public sealed record HistoryRequest(bool OnlyIncompleted, int Count, string? Token = null)
    : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>(3)
        {
            [nameof(Count)] = Count.ToString()
        };

        if (Token is not null)
            values.Add(nameof(Token), Token);

        if (OnlyIncompleted)
            values.Add(nameof(OnlyIncompleted), "true");

        return QueryString.Create(values);
    }
}
