using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.DateGuesser.Model;

public sealed record DateGuesserConclusionModel(
    uint MaxScore,
    ScoreModel Score,
    InternalMoneyModel[] Rewards,
    QuestionModel[] Questions
);

public sealed record QuestionModel(
    ArticleTitleModel Article,
    string Title,
    ScoreModel Score,
    HistoricalDateModel CorrectAnswer,
    HistoricalDateModel UserAnswer
)
{
    public bool IsCorrect =>
        CorrectAnswer == UserAnswer;
}
