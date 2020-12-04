using System.Collections.Generic;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public abstract record TestAnswerResult(bool IsComplete, bool IsCorrect, Score? Score);

    public sealed record TestSingleAnswerResult(bool IsComplete, bool IsCorrect, string Answer, Score? Score)
        : TestAnswerResult(IsComplete, IsCorrect, Score);

    public sealed record TestManyAnswersResult(
        bool IsComplete,
        bool IsCorrect,
        IEnumerable<string> Answers,
        Score? Score
    ) : TestAnswerResult(IsComplete, IsCorrect, Score);
}