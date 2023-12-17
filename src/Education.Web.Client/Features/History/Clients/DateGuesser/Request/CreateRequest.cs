using Education.Web.Client.Features.History.Clients.DateGuesser.Model;

namespace Education.Web.Client.Features.History.Clients.DateGuesser.Request;

public sealed record CreateRequest(DateGuesserType Type, EpochType Epoch);
