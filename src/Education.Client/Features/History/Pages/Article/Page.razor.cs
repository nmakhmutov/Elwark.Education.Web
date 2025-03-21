using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.History.Pages.Article;

public partial class Page : ComponentBase
{
    private readonly IHistoryArticleClient _articleClient;
    private ApiResult<UserArticleDetailModel> _response = ApiResult<UserArticleDetailModel>.Loading();

    public Page(IHistoryArticleClient articleClient) =>
        _articleClient = articleClient;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        _response = ApiResult<UserArticleDetailModel>.Loading();
        _response = await _articleClient.GetAsync(Id);
    }
}
