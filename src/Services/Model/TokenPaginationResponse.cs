namespace Education.Web.Services.Model;

public sealed record TokenPaginationResponse<T>(T[] Items, string? Next);
