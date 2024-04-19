using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Account;
using Education.Client.Features.Customer.Services.Account.Model;
using Education.Client.Features.History;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.Customer.Pages.Account;

public sealed partial class Page
{
    private ApiResult<SubjectModel[]> _response = ApiResult<SubjectModel[]>.Loading();
    private SubjectEnhancedModel[] _subjects = [];

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IAccountClient AccountClient { get; init; } = default!;

    [Inject]
    private IConfiguration Configuration { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _response = await AccountClient.GetSubjectsAsync();
        _subjects = _response.Map(subjects => subjects.Select(x => Enhance(x)).Where(x => x is not null).ToArray())
            .UnwrapOrElse(() => [])!;
    }

    private SubjectEnhancedModel? Enhance(SubjectModel model) =>
        model switch
        {
            { Name: "History" } =>
                new SubjectEnhancedModel(
                    L["History_Title"],
                    HistoryUrl.Root,
                    HistoryUrl.User.MyDashboard,
                    EduIcons.History,
                    "linear-gradient(45deg, #ffa726 10%, #ef6c00 90%)",
                    model.Level,
                    model.Experience,
                    model.Threshold
                ),
            _ => null
        };

    private sealed record SubjectEnhancedModel(
        string Title,
        string SubjectHref,
        string ProfileHref,
        string Icon,
        string Gradient,
        uint Level,
        ulong Experience,
        ulong Threshold
    );
}
