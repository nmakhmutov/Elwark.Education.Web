using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record CurrentTest(string Id, string Title, DateTime ExpiredAt);
}
