using System.Collections.Generic;

namespace Education.Client.Gateways.Models.Test
{
    public abstract record TestAnswerResult(bool IsAnswerCorrect, bool IsTestComplete);

    public sealed record TextAnswerResult(bool IsAnswerCorrect, bool IsTestComplete, string Text)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);

    public sealed record OneAnswerResult(bool IsAnswerCorrect, bool IsTestComplete, int Number)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);

    public sealed record ManyAnswersResult(bool IsAnswerCorrect, bool IsTestComplete, IEnumerable<int> Numbers)
        : TestAnswerResult(IsAnswerCorrect, IsTestComplete);
}
