namespace Education.Web.Gateways.Models;

public sealed record OffsetResponse<T>(T[] Items, uint Pages, long Count);
