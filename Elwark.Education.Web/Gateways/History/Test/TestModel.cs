using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Test
{
    internal sealed record TestModel(
        string Id,
        string Title,
        TestDifficulty Difficulty,
        int AnswerAttempts,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        TestQuestionModel[] Questions
    );
}
