using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Test
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
