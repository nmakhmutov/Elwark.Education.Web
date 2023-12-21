namespace Education.Client.Models;

public sealed record PagingTokenModel<T>(string? Next, T[] Items);
