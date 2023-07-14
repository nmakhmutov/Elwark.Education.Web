namespace Education.Web.Client.Models.Inventory;

public sealed record InventoryCategoryModel(CategoryType Type, string Title);

public enum CategoryType
{
    None = 0,
    Profile = 1,
    Quiz = 2,
    Examination = 3,
    DateGuesser = 4
}
