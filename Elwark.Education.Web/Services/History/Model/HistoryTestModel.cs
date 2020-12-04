using System;
using System.Collections.Generic;
using Elwark.Education.Web.Model;
using Elwark.Education.Web.Services.User.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTestModel(
        string Id,
        DateTime CreatedAt,
        DateTime ExpiredAt,
        bool IsComplete,
        Score? Score,
        IEnumerable<HistoryTestQuestionModel> Questions
    );
}