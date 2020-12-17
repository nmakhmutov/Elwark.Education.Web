using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTestModel(
        string Id,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        Score? Score,
        IEnumerable<HistoryTestQuestionModel> Questions
    );
}