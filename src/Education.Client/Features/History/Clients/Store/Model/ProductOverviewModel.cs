namespace Education.Client.Features.History.Clients.Store.Model;

public sealed record ProductOverviewModel(
    string ProductId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Selling,
    PriceModel Purchasing
) : Product(ProductId, Title, Overview, ImageUrl, Weight);
