using Education.Web.Client.Models;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Flow.Model;

public sealed record FlowModel(uint Streak, Question Question, InternalMoneyModel[] Bank);
