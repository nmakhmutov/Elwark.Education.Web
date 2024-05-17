using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Articles;

public partial class ArticleMainPage : ComponentBase
{
    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Articles_RecentActivity_Title"], null, true)
    ];
}
