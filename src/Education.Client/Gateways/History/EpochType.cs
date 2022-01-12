namespace Education.Client.Gateways.History;

public enum EpochType
{
    None = 0,
    Prehistory = 1,
    Ancient = 2,
    MiddleAges = 3,
    EarlyModern = 4,
    Modern = 5
}

public static class EpochTypeExtensions
{
    public static string ToFastString(this EpochType type) =>
        type switch
        {
            EpochType.None => nameof(EpochType.None).ToLowerInvariant(),
            EpochType.Prehistory => nameof(EpochType.Prehistory).ToLowerInvariant(),
            EpochType.Ancient => nameof(EpochType.Ancient).ToLowerInvariant(),
            EpochType.MiddleAges => nameof(EpochType.MiddleAges).ToLowerInvariant(),
            EpochType.EarlyModern => nameof(EpochType.EarlyModern).ToLowerInvariant(),
            EpochType.Modern => nameof(EpochType.Modern).ToLowerInvariant(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}
