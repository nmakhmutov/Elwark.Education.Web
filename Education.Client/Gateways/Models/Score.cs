namespace Education.Client.Gateways.Models
{
    public sealed record Score(ulong Total, uint Questions, uint NoMistakes, uint Speed);
}
