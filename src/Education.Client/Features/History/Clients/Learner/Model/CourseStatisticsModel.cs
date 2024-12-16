using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Learner.Model;

public sealed record CourseStatisticsModel(
    CourseOverviewModel Course,
    UserCourseActivityModel Activity,
    CourseStatisticsModel.TotalModel Total,
    CourseStatisticsModel.ProgressModel EasyExamination,
    CourseStatisticsModel.ProgressModel HardExamination
)
{
    public sealed record TotalModel(ulong Examinations, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record ProgressModel(
        ScoreModel Score,
        AnswerRatioModel Ratio,
        TimeSpan TimeSpent,
        NumberOfExaminationsModel NumberOfExaminations,
        ConclusionModel[] Conclusions
    );

    public sealed record ConclusionModel(
        ExaminationStatus Status,
        ScoreModel Score,
        AnswerRatioModel Ratio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
