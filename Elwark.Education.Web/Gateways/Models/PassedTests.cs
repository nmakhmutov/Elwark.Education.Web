namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record PassedTests(uint Total, uint Completed, uint TimeExceeded, uint RepliesExceeded);
}