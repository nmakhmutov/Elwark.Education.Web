using System;

namespace Elwark.Education.Web.Gateways.Models
{
    public record ContentRating(double Value, bool? IsLiked)
    {
        public double FiveStarts => Math.Round(Value / 20, 1);
    }
}
