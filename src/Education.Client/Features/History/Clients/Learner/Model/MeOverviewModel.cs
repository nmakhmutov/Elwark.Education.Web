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

    public sealed record ExaminationModel(uint Easy, uint Hard)
    {
        public uint Total =>
            Easy + Hard;
    }

    public sealed record QuizModel(uint Easy, uint Hard, uint Expert)
    {
        public uint Total =>
            Easy + Hard + Expert;
    }

    public sealed record DateGuesserModel(uint Small, uint Medium, uint Large)
    {
        public uint Total =>
            Small + Medium + Large;
    }
}
