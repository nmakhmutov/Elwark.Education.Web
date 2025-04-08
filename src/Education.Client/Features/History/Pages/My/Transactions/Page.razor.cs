using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Transactions;

public sealed partial class Page : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;

    public Page(IStringLocalizer<App> localizer)
    {
        _localizer = localizer;
        _breadcrumbs = _breadcrumbs =
        [
            new BreadcrumbItem(localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(localizer["Finance_Title"], HistoryUrl.User.MyFinance),
            new BreadcrumbItem(localizer["Transactions_Title"], null, true)
        ];
    }
}

