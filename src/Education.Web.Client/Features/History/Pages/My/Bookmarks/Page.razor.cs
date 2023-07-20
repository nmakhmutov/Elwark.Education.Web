using Blazored.LocalStorage;
using Education.Web.Client.Features.History.Pages.My.Bookmarks.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Bookmarks;

public sealed partial class Page
{
    private BookmarksFilter _filter = BookmarksFilter.Empty;

    private List<BreadcrumbItem> Breadcrumbs =>
        new()
        {
            new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile)
        };

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; set; } = default!;

    protected override async Task OnInitializedAsync() =>
        _filter = await Storage.GetItemAsync<BookmarksFilter>(HistoryLocalStorageKey.BookmarkSettings) ??
                  BookmarksFilter.Empty;

    private async Task OnFilterChanged(BookmarksFilter filter)
    {
        _filter = filter;
        await Storage.SetItemAsync(HistoryLocalStorageKey.BookmarkSettings, filter);
    }
}
