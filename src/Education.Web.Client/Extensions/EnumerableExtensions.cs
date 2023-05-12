namespace Education.Web.Client.Extensions;

internal static class EnumerableExtensions
{
    internal static IEnumerable<T> FillDailyGaps<T>(
        this IEnumerable<T> source,
        DateOnly start,
        DateOnly end,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero)
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        for (var day = start; day <= end; day = day.AddDays(1))
            yield return dictionary.GetValueOrDefault(day, zero(day));
    }
    
    internal static IEnumerable<T> FillDailyGaps<T>(
        this IEnumerable<T> source,
        DateOnly today,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero)
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        var start = dictionary.MinBy(x => x.Key).Key;
        for (var day = start; day <= today; day = day.AddDays(1))
            yield return dictionary.GetValueOrDefault(day, zero(day));
    }

    internal static IEnumerable<T> FillMonthlyGaps<T>(
        this IEnumerable<T> source,
        DateOnly today,
        Func<T, DateOnly> key,
        Func<DateOnly, T> zero)
    {
        var dictionary = source.ToDictionary(key);
        if (dictionary.Count == 0)
            yield break;

        var startFound = false;
        var min = dictionary.MinBy(x => x.Key).Key;
        var start = new DateOnly(min.Year, min.Month, 1);
        var end = new DateOnly(today.Year, today.Month, 1);

        for (var month = start; month <= end; month = month.AddMonths(1))
        {
            if (startFound)
            {
                yield return dictionary.GetValueOrDefault(month, zero(month));

                continue;
            }

            startFound = dictionary.TryGetValue(month, out var value);
            if (startFound)
                yield return value!;
        }
    }
}
