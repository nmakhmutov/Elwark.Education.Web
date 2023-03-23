using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.EventGuesser.Model;

public sealed record EventGuesserConclusionModel(
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
