using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Articles;

public sealed partial class ArticleDetailPage : ComponentBase
{
    private ApiResult<ArticleStatisticsModel> _response = ApiResult<ArticleStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync() =>
        _response = await LearnerClient.GetArticleAsync(Id);
}
