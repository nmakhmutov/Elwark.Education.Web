using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.User
{
    public sealed record CurrentTest(TestType Type, string Id, DateTime ExpiredAt);
}
