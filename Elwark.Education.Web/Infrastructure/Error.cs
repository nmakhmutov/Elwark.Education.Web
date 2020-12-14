namespace Elwark.Education.Web.Infrastructure
{
    public sealed record Error(string Type, string Title, string Detail)
    {
        public static Error NotFound = new Error("NotFound", "Not Found", string.Empty);
    };
}