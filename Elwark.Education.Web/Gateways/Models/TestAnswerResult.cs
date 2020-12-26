namespace Elwark.Education.Web.Gateways.Models
{
    public abstract record TestAnswerResult(bool IsCorrect, bool IsComplete);

    public sealed record TextAnswerResult(bool IsCorrect, bool IsComplete, string Text)
        : TestAnswerResult(IsCorrect, IsComplete);
    
    public sealed record SingleAnswerResult(bool IsCorrect, bool IsComplete, int Number)
        : TestAnswerResult(IsCorrect, IsComplete);

    public sealed record ManyAnswersResult(bool IsCorrect, bool IsComplete, int[] Numbers)
        : TestAnswerResult(IsCorrect, IsComplete);
}