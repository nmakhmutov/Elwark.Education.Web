using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test
{
    internal sealed record TestModel(
        string Id,
        TestType TestType,
        int AllowedMistakes,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        TestQuestion[] Questions
    );
}
