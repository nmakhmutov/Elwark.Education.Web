namespace Education.Web.Client.Features.History.Services.Search.Request;

public sealed record SearchRequest(string Q, bool IncludeCategories, string[] Categories, int Offset, int Limit)
{
    public SearchRequest(string q, int offset, int limit)
        : this(q, false, Array.Empty<string>(), offset, limit)
    {
    }
}
