using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Models.Inventory;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History;

internal static class LocalizationExtensions
{
    public static string GetEpochTitle(this IStringLocalizer localizer, EpochType epoch) =>
        localizer[$"History_Epoch_{epoch}"];

    public static string GetQuizDifficultyTitle(this IStringLocalizer localizer, DifficultyType type) =>
        localizer[$"Quiz_{type}_Title"];

    public static string GetExaminationDifficultyTitle(this IStringLocalizer localizer, DifficultyType type) =>
        localizer[$"Examination_{type}_Title"];

    public static string GetDateGuesserSizeTitle(this IStringLocalizer localizer, DateGuesserSize size) =>
        localizer[$"History_DateGuesser_{size}_Title"];

    public static string GetStatusTitle(this IStringLocalizer localizer, QuizStatus status) =>
        localizer[$"ConclusionStatus_{status}"];

    public static string GetStatusTitle(this IStringLocalizer localizer, ExaminationStatus status) =>
        localizer[$"ConclusionStatus_{status}"];

    public static string GetGameCurrencyTitle(this IStringLocalizer localizer, GameCurrency currency) =>
        localizer[$"GameMoney_{currency}"];

    public static string GetInventoryCategoryTitle(this IStringLocalizer localizer, CategoryType type) =>
        localizer[type == CategoryType.None ? "History_Inventory_Category_All" : $"History_Inventory_Category_{type}"];

    public static string GetInventoryCategoryTitles(this IStringLocalizer localizer, IEnumerable<CategoryType> types)
    {
        var list = types.Select(type => localizer[$"History_Inventory_Category_{type}"]);
        return string.Join(", ", list);
    }

    public static string GetStatusTitle(this IStringLocalizer localizer, ArticleLearningStatus status) =>
        localizer[$"ArticleLearningStatus_{status}_Title"];

    public static string GetStatusDescription(this IStringLocalizer localizer, ArticleLearningStatus status) =>
        localizer[$"ArticleLearningStatus_{status}_Description"];

    public static string GetStatusTitle(this IStringLocalizer localizer, CourseLearningStatus status) =>
        localizer[$"CourseLearningStatus_{status}_Title"];

    public static string GetStatusDescription(this IStringLocalizer localizer, CourseLearningStatus status) =>
        localizer[$"CourseLearningStatus_{status}_Description"];

    public static MarkupString Markup(this IStringLocalizer localizer, string name, params object[] arguments) =>
        (MarkupString)localizer[name, arguments].Value;

    public static string GetContentQualityTitle(this IStringLocalizer localizer, ContentQuality quality) =>
        localizer[$"Feedback_Quality_{quality}_Title"];
}
