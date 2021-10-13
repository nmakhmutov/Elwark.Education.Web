using System;

namespace Education.Client.Gateways.Models.Content;

public record ContentRating(double Value, uint Votes)
{
    public double FiveStarts => Math.Round(Value / 20, 1);
}