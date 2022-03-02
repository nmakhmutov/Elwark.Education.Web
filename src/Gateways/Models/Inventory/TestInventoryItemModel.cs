namespace Education.Web.Gateways.Models.Inventory;

public sealed record TestInventoryItemModel(uint Id, uint Count, string Title, string Overview, bool IsApplicable);
