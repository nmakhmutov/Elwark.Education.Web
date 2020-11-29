using System;
using System.Collections.Generic;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record TotalProgress(Total Total, IEnumerable<Progress> Subjects);
    
    public sealed record Progress(
        Subject Subject,
        long PassedTests,
        TimeSpan ElapsedTime,
        Score Score,
        Answers Answers,
        Content? Article,
        Content? Topic
    );

    public sealed record Answers(long Total, int Correct, int Incorrect);

    public sealed record Content(long Tests, TimeElapsedRange TimeElapsed, Score Score, Answers Answers);

    public sealed record Score(long Total, int Questions, int Unmistakable, int Speed);

    public sealed record TimeElapsedRange(TimeSpan Total, ElapsedTime Max, ElapsedTime Min);

    public sealed record ElapsedTime(string Id, TimeSpan Value);

    public sealed record Total(long PassedTests, TimeSpan ElapsedTime, Score Score, Answers Answers);
}