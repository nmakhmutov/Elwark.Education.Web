namespace Education.Web.Client.Features.History.Services.Search.Model;

public sealed record SearchResultModel(SearchModel[] Hints, IReadOnlyDictionary<string, int>? Categories, long Count)
{
    public static SearchResultModel Empty = new(Array.Empty<SearchModel>(), new Dictionary<string, int>(), 0);
}
