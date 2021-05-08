namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record NumberOfTests(uint Total, uint Completed, uint TimeExceeded, uint RepliesExceeded);
}
