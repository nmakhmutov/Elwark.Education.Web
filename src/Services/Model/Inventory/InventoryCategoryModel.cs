namespace Education.Web.Services.Model.Inventory;

public sealed record InventoryCategoryModel(CategoryType Type, string Title);

public enum CategoryType
{
    Profile = 0,
    Test = 1,
    EventGuesser = 2
}
