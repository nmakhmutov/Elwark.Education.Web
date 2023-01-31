using Education.Http;
using Education.Web.Client.Services.History.Article.Model;
using Education.Web.Client.Services.History.Article.Request;
using Education.Web.Client.Services.Model;

namespace Education.Web.Client.Services.History.Article;

public interface IHistoryArticleService
{
    Task<ApiResult<PagingOffsetModel<UserArticleOverviewModel>>> GetAsync(GetArticlesRequest request);

    Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request);

    Task<ApiResult<ArticleCompositionModel>> GetAsync(string id);

    Task<ApiResult<SpotlightModel>> GetSpotlightAsync();

    Task<ApiResult<string>> GetRandomAsync(EpochType epoch);
}
