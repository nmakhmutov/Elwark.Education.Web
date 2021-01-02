namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record CompletedTests(uint Total, uint Completed, uint TimeExceeded, uint RepliesExceeded);
}