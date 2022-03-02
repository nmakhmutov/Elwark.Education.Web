namespace Education.Web.Gateways.Models;

public record PageRequest(int Page, int Count)
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
