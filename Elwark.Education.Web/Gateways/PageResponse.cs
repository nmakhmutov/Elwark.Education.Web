namespace Elwark.Education.Web.Gateways
{
    public sealed record PageResponse<T>(T[] Items, string? Token);
}