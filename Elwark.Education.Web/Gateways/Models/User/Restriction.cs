using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Permission(int Quantity, TestStatus Status, DateTime? RestoreAt);
}
