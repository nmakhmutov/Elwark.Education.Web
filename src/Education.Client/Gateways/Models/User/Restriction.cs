using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.User;

public sealed record Restriction(int Quantity, int Threshold, DateTime? RestoreAt);

public sealed record UserTestPermission(TestPermissionStatus Status, Restriction Restriction);

public sealed record UserSimplePermission(SimplePermissionStatus Status, Restriction Restriction);
