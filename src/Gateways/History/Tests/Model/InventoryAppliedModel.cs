using Education.Web.Gateways.Models.Inventory;
using Education.Web.Gateways.Models.Test;

namespace Education.Web.Gateways.History.Tests.Model;

public sealed record InventoryAppliedModel(
    TestOverviewModel Overview,
    TestQuestionModel? Question,
    TestInventoryItemModel[] Inventory
);
