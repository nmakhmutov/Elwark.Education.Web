using System;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record ArticleProgress(DateTime TestPassedAt, int PassedTimes);
}