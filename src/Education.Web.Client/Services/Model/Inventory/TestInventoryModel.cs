namespace Education.Web.Client.Services.Model.Inventory;

public sealed record TestInventoryModel(
    uint Id,
    uint Quantity,
    string Title,
    string Overview,
    string IconUrl,
    bool IsApplicable
);
