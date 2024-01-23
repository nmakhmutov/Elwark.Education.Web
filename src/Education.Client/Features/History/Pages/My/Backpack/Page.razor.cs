using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Backpack;

public sealed partial class Page
{
    private ProfileModel _profile = ProfileModel.Empty;
    private ApiResult<BackpackModel> _result = ApiResult<BackpackModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _profile = (await UserClient.GetProfileAsync())
            .Map(x => x)
            .UnwrapOrElse(() => _profile);

        _result = await UserClient.GetBackpackAsync();
    }
}
