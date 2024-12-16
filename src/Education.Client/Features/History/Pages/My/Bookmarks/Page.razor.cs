using Education.Client.Features.History.Pages.My.Bookmarks.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Bookmarks;

public sealed partial class Page : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;
    private BookmarksFilter _filter = BookmarksFilter.Empty;

    public Page(IStringLocalizer<App> localizer)
    {
        _localizer = localizer;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Bookmarks_Title"], null, true)
        ];
    }
}
