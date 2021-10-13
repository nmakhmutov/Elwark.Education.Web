using System;

namespace Education.Client.Gateways.History.EventGuesser.Models;

public sealed record TestModel(
    DateTime X2BonusUntil,
    uint Score,
    TestQuestionModel[] Questions
);
    
public sealed record TestQuestionModel(string Id, string Title, bool IsAnswered);
