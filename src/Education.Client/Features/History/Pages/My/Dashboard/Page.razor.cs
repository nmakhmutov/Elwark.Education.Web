using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Dashboard;

public sealed partial class Page
{
    private ApiResult<ProfileStatisticsModel> _result = ApiResult<ProfileStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync() =>
        _result = await UserClient.GetStatisticsAsync();
}
