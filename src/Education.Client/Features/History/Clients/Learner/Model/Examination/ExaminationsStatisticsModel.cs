using Education.Client.Features.History.Clients.Examination.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record ExaminationsStatisticsModel(
    ExaminationsStatisticsModel.ExaminationModel EasyExamination,
    ExaminationsStatisticsModel.ExaminationModel HardExamination,
    ExaminationsStatisticsModel.ProgressModel[] Daily,
    ExaminationsStatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record ExaminationModel(NumberOfExaminationsModel NumberOfExaminations, ScoreModel Score);

    public sealed record ProgressModel(DateOnly Date, uint Easy, uint Hard);
}
