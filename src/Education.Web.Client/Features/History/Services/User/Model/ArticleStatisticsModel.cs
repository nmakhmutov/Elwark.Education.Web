using Education.Web.Client.Features.History.Services.Test.Model;
using Education.Web.Client.Features.History.Services.User.Model.Test;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record ArticleStatisticsModel(
    ArticleOverviewModel Article,
    ArticleStatisticsModel.TotalModel Total,
    ArticleStatisticsModel.ProgressModel EasyTest,
    ArticleStatisticsModel.ProgressModel HardTest
)
{
    public sealed record TotalModel(ulong Tests, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record ConclusionModel(
        TestStatus Status,
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
