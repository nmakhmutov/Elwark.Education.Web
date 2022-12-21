namespace Education.Web.Client.Services.Model.Content;

public sealed record ContentRatingModel(double Rating, uint Votes)
{
    public double Stars =>
        Math.Round(Rating / 20, 1);
}
