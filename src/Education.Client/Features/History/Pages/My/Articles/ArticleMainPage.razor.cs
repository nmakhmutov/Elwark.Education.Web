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
    private ApiResult<PagingTokenModel<UserArticleOverviewModel>> _response =
        ApiResult<PagingTokenModel<UserArticleOverviewModel>>.Loading();

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Articles_RecentActivity_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _response = await LearnerClient.GetArticlesAsync(new ArticleActivityRequest(50));
}
