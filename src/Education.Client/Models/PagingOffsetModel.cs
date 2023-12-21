namespace Education.Client.Models;

public sealed record PagingOffsetModel<T>(long Count, T[] Items);
