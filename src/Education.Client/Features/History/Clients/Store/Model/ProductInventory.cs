using System.Text.Json.Serialization;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Store.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(SystemModel), "system"),
 JsonDerivedType(typeof(LimitedModel), "limited"),
 JsonDerivedType(typeof(StockedModel), "stocked"),
 JsonDerivedType(typeof(UpcomingModel), "upcoming")]
public abstract record ProductInventory(
    string ProductId,
    uint InventoryId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Selling,
    CategoryType[] Categories
) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling)
{
    public sealed record SystemModel(
        string ProductId,
        uint InventoryId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        PriceModel Purchasing,
        CategoryType[] Categories
    ) : ProductInventory(ProductId, InventoryId, Title, Overview, ImageUrl, Weight, Selling, Categories);

    public sealed record LimitedModel(
        string ProductId,
        uint InventoryId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        DateTime AvailableUntil,
        CategoryType[] Categories
    ) : ProductInventory(ProductId, InventoryId, Title, Overview, ImageUrl, Weight, Selling, Categories);

    public sealed record StockedModel(
        string ProductId,
        uint InventoryId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        uint AvailableStock,
        CategoryType[] Categories
    ) : ProductInventory(ProductId, InventoryId, Title, Overview, ImageUrl, Weight, Selling, Categories);


    internal sealed record UpcomingModel(
        string ProductId,
        uint InventoryId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        uint RequiredLevel,
        CategoryType[] Categories
    ) : ProductInventory(ProductId, InventoryId, Title, Overview, ImageUrl, Weight, Selling, Categories);
}
