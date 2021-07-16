namespace Education.Client.Gateways.Models
{
    public sealed record NumberOfTests(uint Total, uint Completed, uint TimeExceeded, uint MistakesExceeded);
}
