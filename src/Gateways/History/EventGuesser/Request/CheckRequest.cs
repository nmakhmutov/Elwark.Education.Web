namespace Education.Web.Gateways.History.EventGuesser.Request;

public sealed record CheckRequest(int Year, uint? Month, uint? Day);
