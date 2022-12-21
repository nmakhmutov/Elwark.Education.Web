using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.Model.Statistics;

public sealed record TestStatisticsModel(
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
    TimeSpentModel TimeSpent,
    NumberOfTestsModel NumberOfTests,
    TestRangeContrastModel RangeContrast,
    TestStatisticsModel.DailyProgress[] Progress
)
{
    public sealed record DailyProgress(
        DateOnly Date,
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpentModel TimeSpent,
        NumberOfTestsModel NumberOfTests
    );
}
