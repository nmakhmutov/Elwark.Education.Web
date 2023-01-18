using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record InventoryAppliedModel(
    TestOverview Overview,
    TestQuestion? Question,
    TestInventoryModel[] Inventory
);
