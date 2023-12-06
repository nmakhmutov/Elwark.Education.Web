using Education.Web.Client.Features.History.Services.Learner.Model.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Learner.Model;

public sealed record ArticleStatisticsModel(
    ArticleOverviewModel Article,
    ArticleStatisticsModel.TotalModel Total,
    ArticleStatisticsModel.ProgressModel EasyQuiz,
    ArticleStatisticsModel.ProgressModel HardQuiz,
    bool IsBookmarked,
    LearningStatus Status
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
