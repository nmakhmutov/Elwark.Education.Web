namespace Education.Client.Features.History.Clients.Store.Model;

public abstract record Product(
    string ProductId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Selling
);
