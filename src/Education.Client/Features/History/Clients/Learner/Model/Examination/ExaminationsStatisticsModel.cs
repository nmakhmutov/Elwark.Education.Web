using Education.Client.Features.History.Clients.Examination.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record ExaminationsStatisticsModel(
    ExaminationsStatisticsModel.ExaminationModel Easy,
    ExaminationsStatisticsModel.ExaminationModel Hard,
    ExaminationProgressModel[] Daily,
    ExaminationProgressModel[] Monthly
)
{
    public sealed record ExaminationModel(NumberOfExaminationsModel NumberOfExaminations, ScoreModel Score);
}
