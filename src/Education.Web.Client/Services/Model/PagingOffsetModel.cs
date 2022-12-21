namespace Education.Web.Client.Services.Model;

public sealed record PagingOffsetModel<T>(uint Pages, long Count, T[] Items);
