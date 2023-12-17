using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Article.Model;
using Education.Web.Client.Features.History.Clients.Article.Request;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Article;

public interface IHistoryArticleClient
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
