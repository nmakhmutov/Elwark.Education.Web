namespace Education.Web.Client.Features.History.Clients.Search.Request;

public sealed record SearchRequest(string Q, bool IncludeCategories, string[] Categories, int Offset, int Limit)
{
    public SearchRequest(string q, int offset, int limit)
        : this(q, false, [], offset, limit)
    {
    }
}
