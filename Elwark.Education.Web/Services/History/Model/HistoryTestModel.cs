using System;
using System.Collections.Generic;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTestModel(
        string Id,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        Score? Score,
        IEnumerable<HistoryTestQuestionModel> Questions
    );
}