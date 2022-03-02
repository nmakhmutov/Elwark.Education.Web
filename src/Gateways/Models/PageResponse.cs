namespace Education.Web.Gateways.Models;

public sealed record PageResponse<T>(T[] Items, uint Pages, long Count);
