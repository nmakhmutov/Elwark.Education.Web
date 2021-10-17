using System.Collections.Generic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Topic;

public sealed record GetEmpiresRequest(GetEmpiresRequest.SortType Sort, int Page, short Count) 
    : PageRequest(Page, Count)
{
    public enum SortType {
        Area = 0,
        Population = 1
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
