using Education.Web.Client.Services.Model.User;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record HistoryProfileModel(
    LevelModel Level,
    SilverWalletModel Silver,
    InventoryOverviewModel Inventory,
    UserTopicOverviewModel[] RecentTopics
);
