using System.Globalization;
using Education.Client.Extensions;
using Education.Client.Features.Customer.Services.Account.Model;

namespace Education.Client.Shared.Customer;

public sealed class CustomerState
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/f_auto,q_auto/v1/People/default.svg";

    private readonly string _dayFormat;
    private readonly char _delimiter;
    private readonly string _monthFormat;
    private readonly string _yearFormat;

    private CustomerState(
        string name,
        string image,
        TimeZoneInfo timeZone,
        string language,
        DayOfWeek startOfWeek,
        string dateFormat,
        string timeFormat,
        DateOnly createdAt
    )
    {
        Name = name;
        Image = image;
        TimeZone = timeZone;
        Language = language;
        StartOfWeek = startOfWeek;
        DateFormat = dateFormat;
        TimeFormat = timeFormat;
        CreatedAt = createdAt;

        _delimiter = dateFormat.First(c => char.IsPunctuation(c));
        (_dayFormat, _monthFormat, _yearFormat) = ParseDateFormat(dateFormat, _delimiter);
    }

    public static CustomerState Anonymous =>
        new(
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local,
            CultureInfo.CurrentCulture.TwoLetterISOLanguageName,
            CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern,
            DateOnly.MinValue
        );

    public string Name { get; }

    public string Image { get; }

    public TimeZoneInfo TimeZone { get; }

    public string Language { get; }

    public DayOfWeek StartOfWeek { get; }

    public string DateFormat { get; }

    public string TimeFormat { get; }

    public DateOnly CreatedAt { get; }

    public static CustomerState Map(CustomerModel customer) =>
        new(
            customer.FullName,
            customer.Image,
            customer.TimeZone,
            customer.Language,
            customer.StartOfWeek,
            customer.DateFormat,
            customer.TimeFormat,
            customer.CreatedAt
        );

    public string Humanize(DateOnly date, DateStyle style = DateStyle.Default) =>
        style switch
        {
            DateStyle.Default => date.ToString(DateFormat),
            DateStyle.CustomerDayAndAbbreviatedMonth => date.ToString($"{_dayFormat} MMM"),
            DateStyle.AbbreviatedMonthAndCustomerYear => date.ToString($"MMM {_yearFormat}"),
            DateStyle.CustomerMonthAndCustomerYear => date.ToString($"{_monthFormat}{_delimiter}{_yearFormat}"),
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };

    public string Humanize(DateTime dateTime) =>
        dateTime.Humanize(TimeZone, DateFormat, TimeFormat);

    private static (string Day, string Month, string Year) ParseDateFormat(string dateFormat, char delimiter)
    {
        var items = dateFormat.Split(delimiter, StringSplitOptions.TrimEntries);
        if (items.Length != 3)
            return ("dd", "MM", "YYYY");

        return (
            items.First(x => x.Contains('d', StringComparison.OrdinalIgnoreCase)),
            items.First(x => x.Contains('m', StringComparison.OrdinalIgnoreCase)),
            items.First(x => x.Contains('y', StringComparison.OrdinalIgnoreCase))
        );
    }
}

public enum DateStyle
{
    Default = 1,
    CustomerDayAndAbbreviatedMonth,
    AbbreviatedMonthAndCustomerYear,
    CustomerMonthAndCustomerYear
}
