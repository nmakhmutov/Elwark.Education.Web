using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Profile;

public sealed partial class Page
{
    private ApiResult<BackpackModel> _result = ApiResult<BackpackModel>.Loading();
    private IReadOnlyCollection<WalletModel> _wallet = [];

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["User_Profile_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _wallet = (await UserClient.GetWalletAsync())
            .Map(x => x)
            .UnwrapOrElse(() => []);

        _result = await UserClient.GetBackpackAsync();
    }
}
