using Education.Web.Client.Features.History.Services.DateGuesser.Model;

namespace Education.Web.Client.Features.History.Services.DateGuesser.Request;

public sealed record CreateRequest(DateGuesserType Type, EpochType Epoch);
