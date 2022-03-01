using Education.Client.Gateways.Models.Inventory;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Tests.Model;

public sealed record TestModel(
    TestOverviewModel Overview,
    TestQuestionModel Question,
    TestInventoryItemModel[] Inventory
);
