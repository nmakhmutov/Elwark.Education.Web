using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.Customers.Requests;

internal sealed record NotificationsRequest(string? Token, int Count) : IQueryStringRequest
{
    public QueryString ToQueryString()
    {
        var values = new Dictionary<string, string?>(2)
        {
            [nameof(Count)] = Count.ToString()
        };
        
        if(Token is not null)
            values.Add(nameof(Token), Token);
        
        return QueryString.Create(values);
    }
}
