using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record UserStatistics(Total Total, Statistic[] Subjects);

    public sealed record Statistic(Subject Subject, long Tests, TimeSpan ElapsedTime, Score Score, Answers Answers);

    public sealed record Answers(long Total, int Correct, int Incorrect);

    public sealed record Total(long Tests, TimeSpan ElapsedTime, Score Score, Answers Answers);
}