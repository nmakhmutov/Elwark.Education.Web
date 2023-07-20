using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My.Profile;

public sealed partial class Page
{
    private ApiResult<ProfileModel> _result = ApiResult<ProfileModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; set; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; set; } = default!;

    protected override async Task OnInitializedAsync() =>
        _result = await UserService.GetProfileAsync();

}
