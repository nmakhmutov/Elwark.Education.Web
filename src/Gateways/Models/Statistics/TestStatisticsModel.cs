using Education.Web.Gateways.Models.Test;

namespace Education.Web.Gateways.Models.Statistics;

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
