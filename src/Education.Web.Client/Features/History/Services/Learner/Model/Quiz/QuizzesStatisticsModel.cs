using Education.Web.Client.Features.History.Services.Quiz.Model;

namespace Education.Web.Client.Features.History.Services.Learner.Model.Quiz;

public sealed record QuizzesStatisticsModel(
    QuizzesStatisticsModel.QuizModel EasyQuiz,
    QuizzesStatisticsModel.QuizModel HardQuiz,
    QuizzesStatisticsModel.ProgressModel[] Daily,
    QuizzesStatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record QuizModel(NumberOfQuizzesModel NumberOfQuizzes, ScoreModel Score);

    public sealed record ProgressModel(DateOnly Date, uint Easy, uint Hard);
}
