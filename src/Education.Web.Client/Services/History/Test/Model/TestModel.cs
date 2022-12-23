using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestModel(
    string Id,
    TestOverviewModel Overview,
    TestQuestionModel Question,
    TestInventoryModel[] Inventory
);
