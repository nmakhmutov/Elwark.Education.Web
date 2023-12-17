using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Learner;
using Education.Web.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.DateGuessers.Details;

public sealed partial class Page
{
    private ApiResult<DateGuesserStatisticsModel> _result = ApiResult<DateGuesserStatisticsModel>.Loading();
    private string? _title;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["History_DateGuessers_Title"], HistoryUrl.User.MyDateGuessers),
        new BreadcrumbItem(_title ?? string.Empty, null, true)
    ];

    [Parameter]
    public required string Test { get; set; }

    protected override async Task OnParametersSetAsync() =>
        (_title, _result) = Test.ToLowerInvariant() switch
        {
            "small" => (L["History_DateGuessers_Small"], await LearnerClient.GetSmallDateGuesserStatisticsAsync()),
            "medium" => (L["History_DateGuessers_Medium"], await LearnerClient.GetMediumDateGuesserStatisticsAsync()),
            "large" => (L["History_DateGuessers_Large"], await LearnerClient.GetLargeDateGuesserStatisticsAsync()),
            _ => (L["Error_NotFound"],
                ApiResult<DateGuesserStatisticsModel>.Fail(Error.Create(L["Error_NotFound"], 404)))
        };
}
