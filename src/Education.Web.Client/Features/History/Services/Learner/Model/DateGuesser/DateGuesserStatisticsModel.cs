using Education.Web.Client.Features.History.Services.DateGuesser.Model;
using Education.Web.Client.Models.Statistics;

namespace Education.Web.Client.Features.History.Services.Learner.Model.DateGuesser;

public sealed record DateGuesserStatisticsModel(
    uint Tests,
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
    DateGuesserStatisticsModel.DeltaModel Delta
)
{
    public sealed record DeltaModel(
        DateOnly Start,
        DateOnly End,
        DeltaModel<uint> Tests,
        ScoreContrastModel Score,
        AnswerRatioContrastModel AnswerRatio
    );

    public sealed record ScoreContrastModel(
        DeltaModel<uint> Total,
        DeltaModel<uint> Points,
        DeltaModel<uint> Bonus
    );

    public sealed record AnswerRatioContrastModel(
        DeltaModel<uint> Total,
        DeltaModel<uint> Correct,
        DeltaModel<uint> Incorrect
    );
}
