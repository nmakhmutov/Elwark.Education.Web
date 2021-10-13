using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test;

internal sealed record TestModel(
    string Id,
    TestType TestType,
    bool CanAnswerAgain,
    int AllowedMistakes,
    DateTime CreatedAt,
    DateTime ExpiredAt,
    TestQuestion[] Questions
);