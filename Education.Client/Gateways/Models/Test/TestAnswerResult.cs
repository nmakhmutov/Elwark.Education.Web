namespace Education.Client.Gateways.Models.Test
{
    public abstract record TestAnswerResult(bool IsCorrect, bool IsTestComplete, int AllowedMistakes);

    public sealed record TextAnswerResult(bool IsCorrect, bool IsTestComplete, int AllowedMistakes, string Text)
        : TestAnswerResult(IsCorrect, IsTestComplete, AllowedMistakes);

    public sealed record OneAnswerResult(bool IsCorrect, bool IsTestComplete, int AllowedMistakes, int Number)
        : TestAnswerResult(IsCorrect, IsTestComplete, AllowedMistakes);

    public sealed record ManyAnswersResult(bool IsCorrect, bool IsTestComplete, int AllowedMistakes, int[] Numbers)
        : TestAnswerResult(IsCorrect, IsTestComplete, AllowedMistakes);
}
