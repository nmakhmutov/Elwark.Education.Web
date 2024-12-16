using Education.Client.Clients;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Course;

public sealed partial class Page : ComponentBase
{
    private readonly IHistoryCourseClient _courseClient;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ApiResult<UserCourseDetailModel> _response = ApiResult<UserCourseDetailModel>.Loading();

    public Page(IHistoryCourseClient courseClient, IHistoryLearnerClient learnerClient, IStringLocalizer<App> localizer)
    {
        _courseClient = courseClient;
        _learnerClient = learnerClient;
        _localizer = localizer;
    }

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync() =>
        _response = await _courseClient.GetAsync(Id);

    private async Task StartCourseAsync(string id)
    {
        var response = await _learnerClient.StartCourseAsync(id);
        _response = response.Map(x => _response.Unwrap() with
        {
            Activity = x
        });
    }
}
