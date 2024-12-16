using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Random;

public sealed partial class Page : ComponentBase
{
    private readonly IHistoryArticleClient _articleClient;
    private readonly IHistoryCourseClient _courseClient;
    private readonly List<OneOf> _history = [];
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ApiResult<OneOf> _response = ApiResult<OneOf>.Loading();

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryArticleClient articleClient,
        IHistoryCourseClient courseClient,
        IHistoryLearnerClient learnerClient
    )
    {
        _localizer = localizer;
        _articleClient = articleClient;
        _courseClient = courseClient;
        _learnerClient = learnerClient;
    }

    protected override Task OnInitializedAsync() =>
        SearchAsync();

    private Task OnSearchClick()
    {
        if (_response.IsLoading)
            return Task.CompletedTask;

        _response.Match(x => _history.Insert(0, x));
        _response = ApiResult<OneOf>.Loading();

        return SearchAsync();
    }

    private async Task SearchAsync() =>
        _response = System.Random.Shared.Next(0, 2) % 2 == 0
            ? (await _articleClient.GetRandomAsync()).Map(x => OneOf.Create(x))
            : (await _courseClient.GetRandomAsync()).Map(x => OneOf.Create(x));
}

public sealed record OneOf(UserArticleOverviewModel? Article, UserCourseOverviewModel? Course)
{
    public static OneOf Create(UserArticleOverviewModel article) =>
        new(article, null);

    public static OneOf Create(UserCourseOverviewModel course) =>
        new(null, course);
}
