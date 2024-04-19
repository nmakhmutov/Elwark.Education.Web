using Education.Client.Features.History.Clients.Examination.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record ExaminationsStatisticsModel(
    ExaminationsStatisticsModel.ExaminationModel EasyExamination,
    ExaminationsStatisticsModel.ExaminationModel HardExamination,
    ExaminationProgressModel[] Daily,
    ExaminationProgressModel[] Monthly
)
{
    public sealed record ExaminationModel(NumberOfExaminationsModel NumberOfExaminations, ScoreModel Score);
}