using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Learner.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My.Articles;

public sealed partial class Page
{
    private ApiResult<ArticleStatisticsModel> _result = ApiResult<ArticleStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnParametersSetAsync() =>
        _result = await LearnerService.GetArticlesAsync(Id);
}
