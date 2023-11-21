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

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Backpack_Title"], null, true)
    ];
    
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