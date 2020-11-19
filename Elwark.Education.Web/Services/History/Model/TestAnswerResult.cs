using System.Collections.Generic;

namespace Elwark.Education.Web.Services.History.Model
{
    public abstract record TestAnswerResult(bool IsComplete, bool IsCorrect, TestResult? Result);

    public sealed record TestSingleAnswerResult(bool IsComplete, bool IsCorrect, string Answer, TestResult? Result)
        : TestAnswerResult(IsComplete, IsCorrect, Result);

    public sealed record TestManyAnswersResult(
            bool IsComplete,
            bool IsCorrect,
            IEnumerable<string> Answers,
            TestResult? Result
        )
        : TestAnswerResult(IsComplete, IsCorrect, Result);
    
    public sealed record TestResult(long TotalScore, int Question, int Speed, int Unmistakable);
}