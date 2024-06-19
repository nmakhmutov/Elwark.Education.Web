using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.History.Pages.Article;

public partial class Page : ComponentBase
{
    private ApiResult<UserArticleDetailModel> _response = ApiResult<UserArticleDetailModel>.Loading();

    [Inject]
    private IHistoryArticleClient ArticleClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        _response = ApiResult<UserArticleDetailModel>.Loading();
        _response = await ArticleClient.GetAsync(Id);
    }
}
