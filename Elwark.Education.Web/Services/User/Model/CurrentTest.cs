using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record CurrentTest(string Id, Subject Subject, string Title, DateTime ExpiredAt);

    public sealed record RestrictionItem(int Quantity, DateTime? RestoreAt);

    public sealed record Restriction(Subject Subject, RestrictionItem TestCreation, RestrictionItem Answer);
    
    public sealed record Answers(long Total, int Correct, int Incorrect);
    
    public sealed record Statistic(Subject Subject, long Tests, TimeSpan ElapsedTime, Score Score, Answers Answers);

    public sealed record Total(long Tests, TimeSpan ElapsedTime, Score Score, Answers Answers);
    
    public sealed record UserStatistics(Total Total, Statistic[] Subjects);
    
    public sealed record Profile(CurrentTest[] CurrentTests, Restriction[] Restrictions, UserStatistics Statistics);
}