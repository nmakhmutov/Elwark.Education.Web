using Education.Client.Models;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserConclusionModel(
    uint MaxScore,
    ScoreModel Score,
    InternalMoneyModel[] Rewards,
    QuestionModel[] Questions
);

public sealed record QuestionModel(
    QuestionModel.ArticleModel Article,
    string Title,
    ScoreModel Score,
    HistoricalDateModel CorrectAnswer,
    HistoricalDateModel UserAnswer
)
{
    public bool IsCorrect =>
        CorrectAnswer == UserAnswer;

    public sealed record ArticleModel(string Id, string Title);
}
