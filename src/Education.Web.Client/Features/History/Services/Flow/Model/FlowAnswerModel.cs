using Education.Web.Client.Models;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Flow.Model;

public sealed record FlowAnswerModel(uint Streak, AnswerResult Answer, InternalMoneyModel[] Bank);