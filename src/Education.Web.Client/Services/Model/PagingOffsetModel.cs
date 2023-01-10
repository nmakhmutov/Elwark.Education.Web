namespace Education.Web.Client.Services.Model;

public sealed record PagingOffsetModel<T>(long Count, T[] Items);
