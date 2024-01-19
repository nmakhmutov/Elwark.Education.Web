using Education.Client.Features.History.Pages.My.Bookmarks.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Bookmarks;

public sealed partial class Page
{
    private BookmarksFilter _filter = BookmarksFilter.Empty;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Bookmarks_Title"], null, true)
    ];
}
