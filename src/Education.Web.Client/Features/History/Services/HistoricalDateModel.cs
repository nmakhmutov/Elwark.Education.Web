namespace Education.Web.Client.Features.History.Services;

public record HistoricalDateModel(int Year, uint? Month, uint? Day)
{
    public bool IsFull =>
        Year > 1 && Month.HasValue && Day.HasValue;
}
