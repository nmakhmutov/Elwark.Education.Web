namespace Education.Client.Gateways.History.EventGuesser.Requests;

public sealed record CheckRequest(string Id, int Year, uint? Month, uint? Day);
