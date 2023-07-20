using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Achievements;

public sealed partial class Page
{
    private ApiResult<AchievementsModel> _result = ApiResult<AchievementsModel>.Loading();
    private string? _subtitle;

    private List<BreadcrumbItem> Breadcrumbs =>
        new()
        {
            new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile)
        };

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; set; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _result = await UserService.GetAchievementsAsync();
        _subtitle = _result.Map(x => $"{x.Unlocked} / {x.Total}")
            .UnwrapOr(string.Empty);
    }
}
