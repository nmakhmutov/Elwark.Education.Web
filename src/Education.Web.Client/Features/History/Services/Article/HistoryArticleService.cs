using Education.Web.Client.Features.History.Services.Article.Model;
using Education.Web.Client.Features.History.Services.Article.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Article;

internal sealed class HistoryArticleService : IHistoryArticleService
{
    private readonly HistoryApiClient _api;

    public HistoryArticleService(HistoryApiClient api) =>
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
