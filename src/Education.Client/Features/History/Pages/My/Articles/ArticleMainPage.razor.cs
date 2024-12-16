using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Articles;

public partial class ArticleMainPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;

    private ApiResult<PagingTokenModel<UserArticleOverviewModel>> _response =
        ApiResult<PagingTokenModel<UserArticleOverviewModel>>.Loading();

    public ArticleMainPage(IHistoryLearnerClient learnerClient, IStringLocalizer<App> localizer)
    {
        _learnerClient = learnerClient;
        _localizer = localizer;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Articles_RecentActivity_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync() =>
        _response = await _learnerClient.GetArticlesAsync(new ArticleActivityRequest(50));
}
