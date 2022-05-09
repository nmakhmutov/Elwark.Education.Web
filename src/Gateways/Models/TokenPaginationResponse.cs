namespace Education.Web.Gateways.Models;

public sealed record TokenPaginationResponse<T>(T[] Items, string? Next);
