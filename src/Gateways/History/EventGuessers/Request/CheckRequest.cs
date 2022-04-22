namespace Education.Web.Gateways.History.EventGuessers.Request;

public sealed record CheckRequest(int Year, uint? Month, uint? Day);
