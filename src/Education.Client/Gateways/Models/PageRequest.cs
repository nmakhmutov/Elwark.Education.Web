using System.Collections.Generic;

namespace Education.Client.Gateways.Models;

public record PageRequest(int Page, short Count)
{
    public virtual string ToQuery() =>
        QueryString.Create(
                new Dictionary<string, string?>
                {
                    { nameof(Page), Page.ToString() },
                    { nameof(Count), Count.ToString() }
                }
            )
            .ToString();
}
