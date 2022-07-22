namespace Education.Web.Services.Model;

public sealed record PagingTokenModel<T>(string? Next, T[] Items);
