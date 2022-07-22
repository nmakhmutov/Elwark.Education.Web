namespace Education.Web.Services.Model;

public sealed record PagingOffsetModel<T>(uint Pages, long Count, T[] Items);
