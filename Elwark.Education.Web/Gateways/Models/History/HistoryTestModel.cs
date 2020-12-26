using System;
using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTestModel(
        string Id,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        bool IsComplete,
        IEnumerable<TestQuestionModel> Questions
    );
}