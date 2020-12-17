using System;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleProgress(DateTime TestPassedAt, int PassedTimes);
}