using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Random;

public sealed partial class Page: ComponentBase
{
    private readonly List<OneOf> _history = new();
    private ApiResult<OneOf> _result = ApiResult<OneOf>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryArticleClient ArticleClient { get; init; } = default!;

    [Inject]
    private IHistoryCourseClient CourseClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

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
            ? (await ArticleClient.GetRandomAsync()).Map(x => OneOf.Create(x))
            : (await CourseClient.GetRandomAsync()).Map(x => OneOf.Create(x));
}

public sealed record OneOf(UserArticleOverviewModel? Article, UserCourseOverviewModel? Course)
{
    public static OneOf Create(UserArticleOverviewModel article) =>
        new(article, null);

    public static OneOf Create(UserCourseOverviewModel course) =>
        new(null, course);
}
