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

    public Task<ApiResult<UserArticleDetailModel>> GetAsync(string id) =>
        _api.GetAsync<UserArticleDetailModel>($"history/articles/{id}");
    
    public Task<ApiResult<UserArticleOverviewModel[]>> GetRelatedArticlesAsync(string id) =>
        _api.GetAsync<UserArticleOverviewModel[]>($"history/articles/{id}/related");

    public Task<ApiResult<UserArticleOverviewModel>> GetRandomAsync(EpochType epoch) =>
        _api.GetAsync<UserArticleOverviewModel>($"history/articles/random?epoch={epoch.ToFastString()}");
}
