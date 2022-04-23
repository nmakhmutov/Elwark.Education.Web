namespace Education.Web.Gateways.Models.Content;

public sealed record ContentRatingModel(double Rating, uint Votes)
{
    public double Stars =>
        Math.Round(Rating / 20, 1);
}
