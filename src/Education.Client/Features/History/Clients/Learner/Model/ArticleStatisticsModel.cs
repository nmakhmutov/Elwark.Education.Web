using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Learner.Model;

public sealed record ArticleStatisticsModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel Activity,
    ArticleStatisticsModel.TotalModel Total,
    ArticleStatisticsModel.ProgressModel EasyQuiz,
    ArticleStatisticsModel.ProgressModel HardQuiz
)
{
    public sealed record TotalModel(ulong Quizzes, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record ConclusionModel(
        QuizStatus Status,
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );

    public sealed record ProgressModel(
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfQuizzesModel NumberOfQuizzes,
        ConclusionModel[] Conclusions
    );
}
