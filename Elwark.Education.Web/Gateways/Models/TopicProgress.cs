using System;
using MudBlazor;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record TopicProgress(
        uint TotalArticles,
        uint CompletedArticles,
        uint QuantityCompletedTimes,
        DateTime? ExamCompletedAt
    )
    {
        public uint Percentage
        {
            get
            {
                var percentage = (uint) Math.Round((double) CompletedArticles / TotalArticles * 100);
                return percentage > 100 ? 100 : percentage;
            }
        }

        public string Color => Percentage switch
        {
            0 or < 10 => Colors.Indigo.Darken1,
            10 or < 20 => Colors.Indigo.Lighten1,
            20 or < 30 => Colors.Blue.Darken3,
            30 or < 40 => Colors.Blue.Darken2,
            40 or < 50 => Colors.Blue.Darken1,
            50 or < 60 => Colors.DeepOrange.Darken1,
            60 or < 70 => Colors.Orange.Darken2,
            70 or < 80 => Colors.Orange.Darken1,
            80 or < 90 => Colors.Orange.Lighten1,
            90 or < 99 => Colors.Green.Lighten2,
            _ => Colors.Green.Lighten1
        };
    }
}