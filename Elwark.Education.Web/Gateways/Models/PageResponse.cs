namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record PageResponse<T>(T[] Items, string? Token);
}