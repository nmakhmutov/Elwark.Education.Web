using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Subject(
        SubjectType Type,
        Subscription Subscription,
        Restriction TestCreating,
        Restriction TestAnswering
    );
}
