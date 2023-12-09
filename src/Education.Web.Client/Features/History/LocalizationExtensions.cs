using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Quiz;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History;

internal static class LocalizationExtensions
{
    public static string GetEpochTitle(this IStringLocalizer localizer, EpochType epoch) =>
        localizer[$"History_Epoch_{epoch}"];

    public static string GetQuizDifficultyTitle(this IStringLocalizer localizer, DifficultyType type) =>
        localizer[$"Quiz_{type}_Title"];

    public static string GetConclusionStatusTitle(this IStringLocalizer localizer, QuizStatus status) =>
        localizer[$"ConclusionStatus_{status}"];

    public static string GetInternalCurrencyTitle(this IStringLocalizer localizer, InternalCurrency currency) =>
        localizer[$"InternalMoney_{currency}"];

    public static string GetInventoryCategoryTypeTitle(this IStringLocalizer localizer, CategoryType type) =>
        localizer[$"History_Inventory_Category_{type}"];

    public static string GetLearningStatusTitle(this IStringLocalizer localizer, LearningStatus status) =>
        localizer[$"LearningStatus_{status}_Title"];

    public static string GetLearningStatusDescription(this IStringLocalizer localizer, LearningStatus status) =>
        localizer[$"LearningStatus_{status}_Description"];

    public static string GetCourseLearningStatusTitle(this IStringLocalizer localizer, CourseLearningStatus status) =>
        localizer[$"CourseLearningStatus_{status}_Title"];
}
