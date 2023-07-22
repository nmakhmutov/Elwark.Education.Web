namespace Education.Web.Client.Features.History.Services.Store.Model;

public sealed record UpcomingInventoriesModel(uint NextLevel, Product.InventoryModel[] Inventories);
