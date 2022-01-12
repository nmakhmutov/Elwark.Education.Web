namespace Education.Client.Gateways.Models.Content;

public record ContentRating(double Rating, uint Votes)
{
    public double Stars => Math.Round(Rating / 20, 1);
}
