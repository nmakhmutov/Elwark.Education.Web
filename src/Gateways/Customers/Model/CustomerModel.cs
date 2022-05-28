namespace Education.Web.Gateways.Customers.Model;

public sealed record CustomerModel(
    long Id,
    string Name,
    string Image,
    string Timezone,
    DayOfWeek WeekStart,
    string Language
);
