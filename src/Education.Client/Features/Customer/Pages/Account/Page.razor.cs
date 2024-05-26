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
    private ApiResult<SubjectModel[]> _response = ApiResult<SubjectModel[]>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IAccountClient AccountClient { get; init; } = default!;

    [Inject]
    private IConfiguration Configuration { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync() =>
        _response = await AccountClient.GetSubjectsAsync();

    private SubjectEnhancedModel? Enhance(SubjectModel model) =>
        model.Name switch
        {
            "History" => new SubjectEnhancedModel(
                L["History_Title"],
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
