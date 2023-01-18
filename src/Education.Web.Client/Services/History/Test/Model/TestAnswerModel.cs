using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestAnswerModel(
    TestOverview Overview,
    AnswerResult Answer,
    TestQuestion? NextQuestion,
    TestInventoryModel[] Inventory
);
