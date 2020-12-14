namespace Elwark.Education.Web.Services
{
    public sealed record PageableResponse<T>(T[] Items, string? Token);
}