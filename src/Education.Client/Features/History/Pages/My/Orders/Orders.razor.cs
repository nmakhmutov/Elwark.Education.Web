using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Orders;

public sealed partial class Orders : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;

    public Orders(IStringLocalizer<App> localizer)
    {
        _localizer = localizer;
        _breadcrumbs =
        [
            new BreadcrumbItem(localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(localizer["Finance_Title"], HistoryUrl.User.MyFinance),
            new BreadcrumbItem(localizer["Orders_Title"], null, true)
        ];
    }
}
