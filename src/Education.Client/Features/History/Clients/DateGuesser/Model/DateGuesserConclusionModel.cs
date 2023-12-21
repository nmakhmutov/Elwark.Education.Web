using Education.Client.Models;
using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

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
