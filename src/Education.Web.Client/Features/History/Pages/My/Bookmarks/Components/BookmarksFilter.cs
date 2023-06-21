using Education.Web.Client.Features.History.Services.User.Request;

namespace Education.Web.Client.Features.History.Pages.My.Bookmarks.Components;

public enum BookmarksCatalog
{
    Articles,
    Courses
}

public sealed record BookmarksFilter(BookmarksCatalog Catalog, BookmarksRequest.SortType Sort)
{
    public static readonly BookmarksFilter Empty = new(
        BookmarksCatalog.Articles,
        BookmarksRequest.SortType.DateAddedNewest
    );
}
