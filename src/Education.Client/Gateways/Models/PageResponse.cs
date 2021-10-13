namespace Education.Client.Gateways.Models;

public sealed record PageResponse<T>(T[] Items, uint Pages, long Count);