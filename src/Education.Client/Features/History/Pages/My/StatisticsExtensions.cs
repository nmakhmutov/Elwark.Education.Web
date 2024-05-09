using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;

namespace Education.Client.Features.History.Pages.My;

public static class StatisticsExtensions
{
    public static string RangeTitle(this ExaminationStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this QuizStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this DateGuesserStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
