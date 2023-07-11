using System.Collections.ObjectModel;

namespace Education.Web.Client.Features.History.Services.Search.Model;

public sealed record SearchResultModel(SearchModel[] Hints, IReadOnlyDictionary<string, int> Categories, long Count)
{
    public static readonly SearchResultModel Empty = new(Array.Empty<SearchModel>(), ReadOnlyDictionary<string, int>.Empty, 0);
}
