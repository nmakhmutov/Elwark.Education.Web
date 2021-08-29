using System;

namespace Education.Client.Gateways.History.DateGuesser
{
    public sealed record DateGuesserTestModel(
        DateTime X2BonusUntil,
        uint TotalPoints,
        TestQuestionModel[] Questions
    );
    
    public sealed record TestQuestionModel(string Id, string Title, bool IsAnswered);
}
