using Education.Web.Client.Models;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Flow.Model;

public sealed record FlowAnswerModel(uint Streak, AnswerResult Answer, InternalMoneyModel[] Bank);
