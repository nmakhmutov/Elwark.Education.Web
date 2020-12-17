using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models
{
    public abstract record TestAnswerResult(bool IsCorrect, Score? Score);

    public sealed record TextAnswerResult(bool IsCorrect, string Text, Score? Score)
        : TestAnswerResult(IsCorrect, Score);

    public sealed record SingleAnswerResult(bool IsCorrect, int Number, Score? Score)
        : TestAnswerResult(IsCorrect, Score);

    public sealed record ManyAnswersResult(bool IsCorrect, IEnumerable<int> Numbers, Score? Score)
        : TestAnswerResult(IsCorrect, Score);
}