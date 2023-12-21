namespace Education.Client.Features.History.Clients.DateGuesser.Request;

public sealed record CheckRequest(int Year, uint? Month, uint? Day);
