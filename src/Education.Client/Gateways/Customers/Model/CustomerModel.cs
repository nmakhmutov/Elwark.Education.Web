namespace Education.Client.Gateways.Customers.Model;

public sealed record CustomerModel(
    long Id,
    string Name,
    Uri Image,
    string Timezone,
    DayOfWeek FirstDayOfWeek,
    string Language
);
