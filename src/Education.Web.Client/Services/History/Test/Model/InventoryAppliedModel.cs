using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record InventoryAppliedModel(
    TestOverviewModel Overview,
    TestQuestionModel? Question,
    TestInventoryItemModel[] Inventory
);
