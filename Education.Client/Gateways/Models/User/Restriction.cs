using System;

namespace Education.Client.Gateways.Models.User
{
    public sealed record Restriction(int Quantity, int Threshold, DateTime? RestoreAt);
}
