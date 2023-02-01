namespace Education.Web.Client.Models;

public sealed record PagingOffsetModel<T>(long Count, T[] Items);
