using System;
using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTestModel(
        string Id,
        string Title,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        IEnumerable<TestQuestionModel> Questions
    );
}