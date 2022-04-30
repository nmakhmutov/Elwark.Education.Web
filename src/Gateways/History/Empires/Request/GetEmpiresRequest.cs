using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Empires.Request;

public sealed record GetEmpiresRequest(GetEmpiresRequest.SortType Sort, int Page, int Count)
    : PageRequest(Page, Count)
{
    public enum SortType
    {
        Area = 0,
        Population = 1,
        Duration = 2
    }

    public override string ToQuery() =>
        QueryString.Create(
                new Dictionary<string, string?>
                {
                    { nameof(Sort), Sort.ToString() },
                    { nameof(Page), Page.ToString() },
                    { nameof(Count), Count.ToString() }
                }
            )
            .ToString();
}
