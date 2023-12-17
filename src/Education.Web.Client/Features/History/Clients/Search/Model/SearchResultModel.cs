using System.Collections.ObjectModel;

namespace Education.Web.Client.Features.History.Clients.Search.Model;

public sealed record SearchResultModel(SearchModel[] Hints, IReadOnlyDictionary<string, int> Categories, long Count)
{
    public static readonly SearchResultModel Empty = new([], ReadOnlyDictionary<string, int>.Empty, 0);
}
