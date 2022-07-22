using Education.Web.Services.Model.Inventory;
using Education.Web.Services.Model.Test;

namespace Education.Web.Services.History.Test.Model;

public sealed record TestModel(
    string Id,
    TestOverviewModel Overview,
    TestQuestionModel Question,
    TestInventoryItemModel[] Inventory
);
