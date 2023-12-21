using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow.Model;

public sealed record FlowAnswerModel(uint Streak, AnswerResult Answer, InternalMoneyModel[] Bank);
