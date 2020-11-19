using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTestModel(
        string Id,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        bool IsComplete,
        TestResult? Result,
        IEnumerable<HistoryTestQuestionModel> Questions
    );
}