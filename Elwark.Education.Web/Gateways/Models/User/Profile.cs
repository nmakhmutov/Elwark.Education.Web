namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Profile(CurrentTest[] CurrentTests, Subject[] Subjects, UserStatistics Statistics);
}