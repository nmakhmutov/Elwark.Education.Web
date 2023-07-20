using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Course;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Random;

public sealed partial class Page
{
    private readonly List<OneOf> _history = new();
    private ApiResult<OneOf> _result = ApiResult<OneOf>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryArticleService ArticleService { get; set; } = default!;

    [Inject]
    private IHistoryCourseService CourseService { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    protected override Task OnInitializedAsync() =>
        SearchAsync();

    private Task OnSearchClick()
    {
        if (_result.IsLoading)
            return Task.CompletedTask;

        _result.Match(x => _history.Insert(0, x));
        _result = ApiResult<OneOf>.Loading();

        return SearchAsync();
    }

    private async Task SearchAsync() =>
        _result = System.Random.Shared.Next(0, 2) % 2 == 0
            ? (await ArticleService.GetRandomAsync()).Map(x => OneOf.Create(x))
            : (await CourseService.GetRandomAsync()).Map(x => OneOf.Create(x));
}

public sealed record OneOf(UserArticleOverviewModel? Article, UserCourseOverviewModel? Course)
{
    public static OneOf Create(UserArticleOverviewModel article) =>
        new(article, null);

    public static OneOf Create(UserCourseOverviewModel course) =>
        new(null, course);
}
