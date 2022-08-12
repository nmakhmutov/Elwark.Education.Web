using Education.Web.Services.Model.User;

namespace Education.Web.Services.History.User.Model;

public sealed record HistoryProfileModel(LevelModel Level, SilverWalletModel Silver, InventoryOverviewModel Inventory);
