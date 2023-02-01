using Education.Web.Client.Models;
using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Article.Model;
using Education.Web.Client.Services.History.Article.Request;

namespace Education.Web.Client.Services.History.Article;

internal sealed class HistoryArticleService : IHistoryArticleService
{
    private readonly ApiClient _api;

    public HistoryArticleService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserArticleOverviewModel>>> GetAsync(GetArticlesRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserArticleOverviewModel>>("history/articles", request);

    public Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request) =>
        _api.GetAsync<PagingOffsetModel<EmpireOverviewModel>>("history/empires", request);

    public Task<ApiResult<ArticleCompositionModel>> GetAsync(string id) =>
        _api.GetAsync<ArticleCompositionModel>($"history/articles/{id}");

    public Task<ApiResult<SpotlightModel>> GetSpotlightAsync() =>
        _api.GetAsync<SpotlightModel>("history/articles/spotlight");

    public Task<ApiResult<string>> GetRandomAsync(EpochType epoch) =>
        _api.GetAsync<string>($"history/articles/random?epoch={epoch.ToFastString()}");
}
