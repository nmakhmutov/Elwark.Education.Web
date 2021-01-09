namespace Elwark.Education.Web.Gateways.Models
{
    public abstract record TestAnswerResult(bool IsAnswerCorrect, bool IsTestComplete);

    public sealed record TextAnswerResult(bool IsAnswerCorrect, bool IsTestComplete, string Text)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);
    
    public sealed record SingleAnswerResult(bool IsAnswerCorrect, bool IsTestComplete, int Number)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);

    public sealed record ManyAnswersResult(bool IsAnswerCorrect, bool IsTestComplete, int[] Numbers)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);
}