namespace Education.Client.Models.Inventory;

public enum CategoryType
{
    None = 0,
    Profile = 1,
    Quiz = 2,
    Examination = 3,
    DateGuesser = 4
}

public static class CategoryTypeExtensions
{
    public static string ToFastString(this CategoryType type) =>
        type switch
        {
            CategoryType.None => nameof(CategoryType.None),
            CategoryType.Profile => nameof(CategoryType.Profile),
            CategoryType.Quiz => nameof(CategoryType.Quiz),
            CategoryType.Examination => nameof(CategoryType.Examination),
            CategoryType.DateGuesser => nameof(CategoryType.DateGuesser),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}
