using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.User;

public sealed record Restriction(int Quantity, int Threshold, DateTime? RestoreAt);

public sealed record TestPermission(TestPermissionStatus Status, Restriction Restriction);

public sealed record SimplePermission(SimplePermissionStatus Status, Restriction Restriction);