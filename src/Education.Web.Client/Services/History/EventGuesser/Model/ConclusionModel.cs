using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Services.History.EventGuesser.Model;

public sealed record ConclusionModel(
    uint MaxScore,
    ScoreModel Score,
    IInternalMoney[] Rewards,
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
