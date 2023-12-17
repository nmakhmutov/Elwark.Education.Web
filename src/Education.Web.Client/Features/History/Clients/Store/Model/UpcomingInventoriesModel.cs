namespace Education.Web.Client.Features.History.Clients.Store.Model;

public sealed record UpcomingInventoriesModel(uint NextLevel, Product.InventoryModel[] Inventories);
