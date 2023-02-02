using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Test.Model;

public sealed record TestAnswerModel(
    TestOverview Overview,
    AnswerResult Answer,
    TestQuestion? NextQuestion,
    TestInventoryModel[] Inventory
);
