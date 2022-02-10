namespace Education.Client.Gateways.Customer;

public sealed record Customer(
    long Id,
    string Name,
    Uri Image,
    string Timezone,
    DayOfWeek FirstDayOfWeek,
    string Language,
    Subject[] Subjects
);
