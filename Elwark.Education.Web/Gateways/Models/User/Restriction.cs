using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    internal sealed record Restriction(int Quantity, DateTime? RestoreAt);
}
