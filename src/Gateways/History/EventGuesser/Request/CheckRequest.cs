namespace Education.Web.Gateways.History.EventGuesser.Request;

public sealed record CheckRequest(string Id, int Year, uint? Month, uint? Day);