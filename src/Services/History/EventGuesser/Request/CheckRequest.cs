namespace Education.Web.Services.History.EventGuesser.Request;

public sealed record CheckRequest(int Year, uint? Month, uint? Day);
