namespace Education.Client.Gateways.Models;

public sealed record NumberOfTests(uint Successful, uint Failed, uint TimeExceeded, uint MistakesExceeded, ulong Total);
