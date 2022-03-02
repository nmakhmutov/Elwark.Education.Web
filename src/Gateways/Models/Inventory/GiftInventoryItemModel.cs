namespace Education.Web.Gateways.Models.Inventory;

public sealed record GiftInventoryItemModel(uint Id, uint Count, string Title, string Overview, DateTime UnlockedAfter);
