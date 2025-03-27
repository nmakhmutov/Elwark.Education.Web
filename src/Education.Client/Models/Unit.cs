namespace Education.Client.Models;

public readonly struct Unit : IEquatable<Unit>, IComparable<Unit>
{
    public static readonly Unit Value = new();

    public int CompareTo(Unit other) =>
        0;

    public override int GetHashCode() =>
        0;

    public bool Equals(Unit other) =>
        true;

    public override bool Equals(object? obj) =>
        obj is Unit;

    public static bool operator ==(Unit first, Unit second) =>
        true;

    public static bool operator !=(Unit first, Unit second) =>
        false;

    public override string ToString() =>
        "()";
}
