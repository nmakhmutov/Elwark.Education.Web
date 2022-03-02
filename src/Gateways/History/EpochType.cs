namespace Education.Web.Gateways.History;

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
            EpochType.None => nameof(EpochType.None),
            EpochType.Prehistory => nameof(EpochType.Prehistory),
            EpochType.Ancient => nameof(EpochType.Ancient),
            EpochType.MiddleAges => nameof(EpochType.MiddleAges),
            EpochType.EarlyModern => nameof(EpochType.EarlyModern),
            EpochType.Modern => nameof(EpochType.Modern),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}
