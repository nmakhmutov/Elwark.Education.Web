using Education.Client.Clients;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination;

internal sealed class HistoryExaminationClient : IHistoryExaminationClient
{
    private const string Root = "history/examinations";
    private readonly HistoryApiClient _api;

    public HistoryExaminationClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ExaminationModel>> GetAsync(string testId) =>
        _api.GetAsync<ExaminationModel>($"{Root}/{testId}");

    public Task<ApiResult<ExaminationAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel model) =>
        _api.PostAsync<ExaminationAnswerModel, UserAnswerModel>($"{Root}/{testId}/questions/{questionId}", model);

    public Task<ApiResult<ExaminationModel>> UseInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<ExaminationModel>($"{Root}/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<ExaminationConclusionModel>> GetConclusionAsync(string testId) =>
        _api.GetAsync<ExaminationConclusionModel>($"{Root}/{testId}/conclusion");
}
