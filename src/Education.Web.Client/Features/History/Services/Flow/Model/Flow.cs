using Education.Web.Client.Models;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Flow.Model;

public sealed record FlowModel(uint Streak, Question Question, IEnumerable<InternalMoneyModel> Bank);
