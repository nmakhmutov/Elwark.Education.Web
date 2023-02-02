using Education.Web.Client.Http;

namespace Education.Web.Client.Features.Customer.Services.Notification.Request;

public sealed record NotificationsRequest(int Count, string? Token = null) : IQueryStringRequest
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
