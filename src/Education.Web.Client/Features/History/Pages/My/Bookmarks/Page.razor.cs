using Education.Web.Client.Features.History.Pages.My.Bookmarks.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Bookmarks;

public sealed partial class Page
{
    private BookmarksFilter _filter = BookmarksFilter.Empty;

    private List<BreadcrumbItem> Breadcrumbs =>
        [new BreadcrumbItem(L["History_Title"], HistoryUrl.Root), new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile)];

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;
}
