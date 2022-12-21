namespace Education.Web.Client.Services.Model;

public sealed record PagingTokenModel<T>(string? Next, T[] Items);
