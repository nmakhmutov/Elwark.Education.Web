using Education.Client.Clients;

namespace Education.Client.Features.History.Clients.Learner.Request;

public sealed record ArticleActivityRequest(int Count, string? Token = null)
    : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>(2)
        {
            [nameof(Count)] = Count.ToString()
        };

        if (Token is not null)
            values.Add(nameof(Token), Token);

        return QueryString.Create(values);
    }
}
