using Education.Web.Client.Features.History.Services.Article.Model;
using Education.Web.Client.Features.History.Services.Article.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Article;

public interface IHistoryArticleService
{
    Task<ApiResult<PagingOffsetModel<UserArticleOverviewModel>>> GetAsync(GetArticlesRequest request);

    Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request);

    Task<ApiResult<PagingOffsetModel<TimelineOverviewModel>>> GetAsync(GetTimelineRequest request);

    Task<ApiResult<UserArticleDetailModel>> GetAsync(string id);

    Task<ApiResult<UserArticleOverviewModel[]>> GetRelatedArticlesAsync(string id);

    Task<ApiResult<UserArticleOverviewModel>> GetRandomAsync(EpochType epoch = EpochType.None);

    Task<ApiResult<ArticleQuizBuilderModel>> GetQuizBuilderAsync(string articleId);

    Task<ApiResult<TestCreationModel>> CreateQuizAsync(string articleId, CreateQuizRequest request);
}
