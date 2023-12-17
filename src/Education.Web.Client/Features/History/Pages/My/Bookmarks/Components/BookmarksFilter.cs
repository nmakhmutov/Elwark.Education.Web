using Education.Web.Client.Features.History.Clients.Learner.Request;

namespace Education.Web.Client.Features.History.Pages.My.Bookmarks.Components;

public sealed record BookmarksFilter(BookmarksRequest.SortType Sort)
{
    public static readonly BookmarksFilter Empty = new(BookmarksRequest.SortType.DateAddedNewest);
}
