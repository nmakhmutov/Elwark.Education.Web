using Education.Client.Clients;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination;

public interface IHistoryExaminationClient
{
    Task<ApiResult<ExaminationModel>> GetAsync(string id);

    Task<ApiResult<ExaminationAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel model);

    Task<ApiResult<ExaminationModel>> UseInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<ExaminationConclusionModel>> GetConclusionAsync(string testId);
}
