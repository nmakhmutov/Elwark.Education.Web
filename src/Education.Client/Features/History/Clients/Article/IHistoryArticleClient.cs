using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Article;

public interface IHistoryArticleClient
{
    Task<ApiResult<PagingOffsetModel<UserArticleOverviewModel>>> GetAsync(GetArticlesRequest request);

    Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request);

    Task<ApiResult<PagingOffsetModel<UserTimelineOverviewModel>>> GetAsync(GetTimelineRequest request);

    Task<ApiResult<UserArticleDetailModel>> GetAsync(string id);

    Task<ApiResult<UserArticleOverviewModel[]>> GetRelatedArticlesAsync(string id);

    Task<ApiResult<CourseOverviewModel[]>> GetCoursesAsync(string id);

    Task<ApiResult<UserArticleOverviewModel>> GetRandomAsync(EpochType epoch = EpochType.None);

    Task<ApiResult<ArticleQuizBuilderModel>> GetQuizBuilderAsync(string articleId);

    Task<ApiResult<TestCreationModel>> CreateQuizAsync(string articleId, CreateQuizRequest request);
}
