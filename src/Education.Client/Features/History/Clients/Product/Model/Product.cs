using System.Text.Json.Serialization;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Product.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(SystemModel), "system"),
 JsonDerivedType(typeof(LimitedModel), "limited"),
 JsonDerivedType(typeof(StockedModel), "stocked"),
 JsonDerivedType(typeof(MoneyModel), "money"),
 JsonDerivedType(typeof(BundleModel), "bundle"),
 JsonDerivedType(typeof(UpcomingModel), "upcoming")]
public abstract record Product(
    string ProductId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Selling,
    CategoryType[] Categories
)
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
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);

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
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);

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
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);

    public sealed record MoneyModel(
        string ProductId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        GameCurrency Currency,
        uint Amount,
        PriceModel Selling,
        CategoryType[] Categories
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);

    public sealed record BundleModel(
        string ProductId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        uint? AvailableStock,
        DateTime? AvailableUntil,
        UserInventoryModel[] Inventories,
        CategoryType[] Categories
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);

    public sealed record UpcomingModel(
        string ProductId,
        uint InventoryId,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Selling,
        uint RequiredLevel,
        CategoryType[] Categories
    ) : Product(ProductId, Title, Overview, ImageUrl, Weight, Selling, Categories);
}
