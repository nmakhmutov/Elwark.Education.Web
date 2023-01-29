using Education.Web.Client.Services.History.EventGuesser.Model;
using Education.Web.Client.Services.Model.Statistics;

namespace Education.Web.Client.Services.History.User.Model.EventGuesser;

public sealed record EventGuesserStatisticsModel(
    uint Tests,
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
    EventGuesserStatisticsModel.ContrastModel RangeContrast
)
{
    public sealed record ContrastModel(
        DateOnly Starts,
        DateOnly Ends,
        ContrastModel<uint> Tests,
        ScoreContrastModel Score,
        AnswerRatioContrastModel AnswerRatio
    );

    public sealed record ScoreContrastModel(
        ContrastModel<uint> Total,
        ContrastModel<uint> Points,
        ContrastModel<uint> Bonus
    );

    public sealed record AnswerRatioContrastModel(
        ContrastModel<uint> Total,
        ContrastModel<uint> Correct,
        ContrastModel<uint> Incorrect
    );
}
