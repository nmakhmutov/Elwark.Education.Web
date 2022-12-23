namespace Education.Web.Client.Services.Model.Inventory;

public sealed record TestInventoryModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    bool IsApplicable
);
