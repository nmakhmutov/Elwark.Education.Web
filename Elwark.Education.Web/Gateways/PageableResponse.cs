namespace Elwark.Education.Web.Gateways
{
    public sealed record PageableResponse<T>(T[] Items, string? Token);
}