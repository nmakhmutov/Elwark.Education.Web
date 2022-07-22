namespace Education.Web.Services.Model;

public sealed record OffsetResponse<T>(T[] Items, uint Pages, long Count);
