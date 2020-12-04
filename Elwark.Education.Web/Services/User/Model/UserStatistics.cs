using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record UserStatistics(Total Total, Statistic[] Subjects);

    public sealed record Statistic(
        Subject Subject,
        long PassedTests,
        TimeSpan ElapsedTime,
        Score Score,
        Answers Answers
    );

    public sealed record Answers(long Total, int Correct, int Incorrect);

    public sealed record Score(long Total, int Questions, int Unmistakable, int Speed);

    public sealed record Total(long PassedTests, TimeSpan ElapsedTime, Score Score, Answers Answers);
}