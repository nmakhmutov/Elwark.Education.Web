using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Account;
using Education.Client.Features.Customer.Services.Account.Model;
using Education.Client.Features.History;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.Customer.Pages.Account;

public sealed partial class Page : ComponentBase
{
    private readonly IAccountClient _accountClient;
    private readonly IConfiguration _configuration;
    private readonly IStringLocalizer<App> _localizer;
    private ApiResult<SubjectModel[]> _response = ApiResult<SubjectModel[]>.Loading();

    public Page(IStringLocalizer<App> localizer, IAccountClient accountClient, IConfiguration configuration)
    {
        _localizer = localizer;
        _accountClient = accountClient;
        _configuration = configuration;
    }

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync() =>
        _response = await _accountClient.GetSubjectsAsync();

    private SubjectEnhancedModel? Enhance(SubjectModel model) =>
        model.Name switch
        {
            "History" => new SubjectEnhancedModel(
                _localizer["History_Title"],
                EduIcons.History,
                "linear-gradient(45deg, #ffa726 10%, #ef6c00 90%)",
                new SubjectEnhancedModel.SubjectLinks(
                    HistoryUrl.Root,
                    HistoryUrl.User.MyDashboard,
                    HistoryUrl.User.MyFinance,
                    HistoryUrl.User.MyBackpack
                ),
                model.Level,
                model.Backpack,
                model.Wallet
            ),
            _ => null
        };
}
