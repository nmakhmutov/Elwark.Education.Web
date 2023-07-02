namespace Education.Web.Client.Features.History.Services.Search.Model;

public sealed record SearchResultModel(
    IEnumerable<SearchModel> Hints,
    IReadOnlyDictionary<string, int>? Categories,
    long Count
);
