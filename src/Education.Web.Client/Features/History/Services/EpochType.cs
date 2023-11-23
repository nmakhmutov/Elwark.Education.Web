namespace Education.Web.Client.Features.History.Services;

public enum EpochType
{
    None = 0,
    Prehistory = 1,
    Ancient = 2,
    MiddleAges = 3,
    EarlyModern = 4,
    LateModern = 5,
    Contemporary = 6
}

public static class EpochTypeExtensions
{
    public static readonly EpochType[] List =
    {
        EpochType.None,
        EpochType.Prehistory,
        EpochType.Ancient,
        EpochType.MiddleAges,
        EpochType.EarlyModern,
        EpochType.LateModern,
        EpochType.Contemporary
    };

    public static string ToFastString(this EpochType type) =>
        type switch
        {
            EpochType.None => nameof(EpochType.None),
            EpochType.Prehistory => nameof(EpochType.Prehistory),
            EpochType.Ancient => nameof(EpochType.Ancient),
            EpochType.MiddleAges => nameof(EpochType.MiddleAges),
            EpochType.EarlyModern => nameof(EpochType.EarlyModern),
            EpochType.LateModern => nameof(EpochType.LateModern),
            EpochType.Contemporary => nameof(EpochType.Contemporary),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

    public static string Image(this EpochType type) =>
        $"https://res.cloudinary.com/elwark/image/upload/f_auto,q_auto/v1/Education/History/Epochs/{type.ToFastString()}.jpg";
}
