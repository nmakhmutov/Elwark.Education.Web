using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record CurrentTest(TestType Type, string Id, DateTime ExpiredAt);
}
