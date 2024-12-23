using Education.Client.Features.History.Clients.Quiz.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.Quiz;

public sealed record QuizzesStatisticsModel(
    QuizzesStatisticsModel.QuizModel Easy,
    QuizzesStatisticsModel.QuizModel Hard,
    QuizzesStatisticsModel.QuizModel Expert,
    QuizProgressModel[] Daily,
    QuizProgressModel[] Monthly
)
{
    public sealed record QuizModel(NumberOfQuizzesModel NumberOfQuizzes, ScoreModel Score);
}
