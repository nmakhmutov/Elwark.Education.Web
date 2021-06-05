using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Restriction(int Quantity, DateTime? RestoreAt);
}
