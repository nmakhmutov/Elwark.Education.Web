namespace Education.Client.Features.History.Clients.Learner.Model;

public sealed record MeOverviewModel(
    uint Examinations,
    uint Quizzes,
    uint DateGuessers,
    MeOverviewModel.ActivityModel[] Activities
)
{
    public sealed record ActivityModel(
        DateOnly Month,
        ExaminationModel Examination,
        QuizModel Quiz,
        DateGuesserModel DateGuesser
    );

    public sealed record ExaminationModel(uint Easy, uint Hard);

    public sealed record QuizModel(uint Easy, uint Hard);

    public sealed record DateGuesserModel(uint Small, uint Medium, uint Large);
}
