using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Learner;
using Education.Web.Client.Features.History.Clients.Learner.Model;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My.Articles;

public sealed partial class Page
{
    private ApiResult<ArticleStatisticsModel> _result = ApiResult<ArticleStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnParametersSetAsync() =>
        _result = await LearnerClient.GetArticlesAsync(Id);
}
