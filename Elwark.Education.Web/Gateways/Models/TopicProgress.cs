using System;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record TopicProgress(uint TotalArticles, uint CompletedArticles, CompletedTimes CompletedTimes)
    {
        public uint Percentage =>
            (uint) Math.Min(Math.Round((double) CompletedArticles / TotalArticles * 100), 100);
    }
}
