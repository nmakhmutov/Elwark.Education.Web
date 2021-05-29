using System;

namespace Elwark.Education.Web.Gateways.Models.Content
{
    public sealed record ContentRating(double Value, uint Votes, bool? IsLiked)
    {
        public double FiveStarts => Math.Round(Value / 20, 1);
    }
}
