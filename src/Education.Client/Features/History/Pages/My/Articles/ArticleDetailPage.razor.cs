using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Articles;

public sealed partial class ArticleDetailPage : ComponentBase
{
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ApiResult<ArticleStatisticsModel> _response = ApiResult<ArticleStatisticsModel>.Loading();

    public ArticleDetailPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
    }

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync() =>
        _response = await _learnerClient.GetArticleAsync(Id);
}
