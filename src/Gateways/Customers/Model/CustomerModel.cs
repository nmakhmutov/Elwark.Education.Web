namespace Education.Web.Gateways.Customers.Model;

public sealed record CustomerModel(
    long Id,
    string Name,
    Uri Image,
    string Timezone,
    DayOfWeek WeekStart,
    string Language
);
