namespace Education.Client.Extensions;

internal static class EnumerableExtensions
{
    internal static IEnumerable<T> FillDailyGaps<T>(
        this IEnumerable<T> source,
        DateOnly start,
        DateOnly end,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero
    )
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        for (var day = start; day <= end; day = day.AddDays(1))
            yield return dictionary.GetValueOrDefault(day, zero(day));
    }

    internal static IEnumerable<T> FillDailyGaps<T>(
        this IEnumerable<T> source,
        DateOnly end,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero
    )
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        var start = dictionary.MinBy(x => x.Key).Key;
        for (var day = start; day <= end; day = day.AddDays(1))
            yield return dictionary.GetValueOrDefault(day, zero(day));
    }

    internal static IEnumerable<T> FillMonthlyGaps<T>(
        this IEnumerable<T> source,
        DateOnly start,
        DateOnly end,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero
    )
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        start = new DateOnly(start.Year, start.Month, 1);
        end = new DateOnly(end.Year, end.Month, 1);

        for (var month = start; month <= end; month = month.AddMonths(1))
            yield return dictionary.GetValueOrDefault(month, zero(month));
    }

    internal static IEnumerable<T> FillMonthlyGaps<T>(
        this IEnumerable<T> source,
        DateOnly end,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero
    )
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        var min = dictionary.MinBy(x => x.Key).Key;
        var start = new DateOnly(min.Year, min.Month, 1);
        end = new DateOnly(end.Year, end.Month, 1);

        for (var month = start; month <= end; month = month.AddMonths(1))
            yield return dictionary.GetValueOrDefault(month, zero(month));
    }
}
