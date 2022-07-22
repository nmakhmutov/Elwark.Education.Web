namespace Education.Web.Services.Model.Inventory;

public sealed record UserInventoryItemModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    Category Category
);

public enum Category
{
    Profile = 0,
    Test = 1,
    EventGuesser = 2,
}
