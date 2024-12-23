using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Article;

internal sealed class HistoryArticleClient : IHistoryArticleClient
{
    private readonly HistoryApiClient _api;

    public HistoryArticleClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserArticleOverviewModel>>> GetAsync(GetArticlesRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserArticleOverviewModel>>("history/articles", request);

    public Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request) =>
        _api.GetAsync<PagingOffsetModel<EmpireOverviewModel>>("history/empires", request);

    public Task<ApiResult<PagingOffsetModel<TimelineOverviewModel>>> GetAsync(GetTimelineRequest request) =>
        _api.GetAsync<PagingOffsetModel<TimelineOverviewModel>>("history/timelines", request);

    public Task<ApiResult<UserArticleDetailModel>> GetAsync(string id) =>
        _api.GetAsync<UserArticleDetailModel>($"history/articles/{id}");

    public Task<ApiResult<UserArticleOverviewModel[]>> GetRelatedArticlesAsync(string id) =>
        _api.GetAsync<UserArticleOverviewModel[]>($"history/articles/{id}/related");

    public Task<ApiResult<CourseOverviewModel[]>> GetCoursesAsync(string id) =>
        _api.GetAsync<CourseOverviewModel[]>($"history/articles/{id}/courses");

    public Task<ApiResult<UserArticleOverviewModel>> GetRandomAsync(EpochType epoch) =>
        _api.GetAsync<UserArticleOverviewModel>($"history/articles/random?epoch={epoch.ToFastString()}");

    public Task<ApiResult<ArticleQuizBuilderModel>> GetQuizBuilderAsync(string id) =>
        _api.GetAsync<ArticleQuizBuilderModel>($"history/articles/{id}/quizzes");

    public Task<ApiResult<TestCreationModel>> CreateQuizAsync(string id, CreateQuizRequest request) =>
        _api.PostAsync<TestCreationModel, CreateQuizRequest>($"history/articles/{id}/quizzes", request);
}
