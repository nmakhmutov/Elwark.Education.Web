namespace Education.Web.Client.Services.Model.Inventory;

public sealed record TestInventoryItemModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    bool IsApplicable
);
