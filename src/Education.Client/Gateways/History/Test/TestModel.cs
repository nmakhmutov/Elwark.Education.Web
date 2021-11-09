using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test;

public sealed record TestModel(
    string Id,
    TestType TestType,
    int AllowedMistakes,
    DateTime CreatedAt,
    DateTime ExpiredAt,
    TestQuestion[] Questions
);
