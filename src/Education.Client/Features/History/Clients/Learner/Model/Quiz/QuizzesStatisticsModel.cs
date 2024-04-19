using Education.Client.Features.History.Clients.Quiz.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.Quiz;

public sealed record QuizzesStatisticsModel(
    QuizzesStatisticsModel.QuizModel EasyQuiz,
    QuizzesStatisticsModel.QuizModel HardQuiz,
    QuizProgressModel[] Daily,
    QuizProgressModel[] Monthly
)
{
    public sealed record QuizModel(NumberOfQuizzesModel NumberOfQuizzes, ScoreModel Score);
}
