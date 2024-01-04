using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Examinations;

public partial class Page
{
    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;
    
    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Examinations_Title"], null, true)
    ];
}
