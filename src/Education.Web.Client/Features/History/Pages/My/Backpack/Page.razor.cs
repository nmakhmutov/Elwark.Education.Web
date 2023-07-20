using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Backpack;

public sealed partial class Page
{
    private string? _capacity;
    private ApiResult<BackpackModel> _result = ApiResult<BackpackModel>.Loading();
    private IReadOnlyCollection<WalletModel> _wallet = Array.Empty<WalletModel>();

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

    protected override async Task OnInitializedAsync()
    {
        _wallet = (await UserService.GetWalletAsync())
            .Map(x => x)
            .UnwrapOr(Array.Empty<WalletModel>());

        _result = await UserService.GetBackpackAsync();
        _capacity = _result.Map(x => $"{x.Fullness} / {x.Capacity}")
            .UnwrapOr(string.Empty);
    }
}
