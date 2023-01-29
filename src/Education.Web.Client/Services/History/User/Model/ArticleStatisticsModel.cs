using Education.Web.Client.Services.History.Test.Model;
using Education.Web.Client.Services.History.User.Model.Test;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record ArticleStatisticsModel(
    ArticleOverviewModel Article,
    ArticleStatisticsModel.TotalModel Total,
    ArticleStatisticsModel.ProgressModel EasyTest,
    ArticleStatisticsModel.ProgressModel HardTest
)
{
    public sealed record TotalModel(ulong Tests, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record ConclusionModel(
        ConclusionStatus Status,
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );

    public sealed record ProgressModel(
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTestsModel NumberOfTests,
        ConclusionModel[] Conclusions
    );
}
