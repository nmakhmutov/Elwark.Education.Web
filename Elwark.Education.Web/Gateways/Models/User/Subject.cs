using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Subject(
        SubjectType SubjectType,
        Subscription Subscription,
        Restriction TestCreating,
        Restriction TestAnswering
    );
}