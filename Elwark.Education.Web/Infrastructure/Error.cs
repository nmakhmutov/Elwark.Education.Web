namespace Elwark.Education.Web.Infrastructure
{
    public sealed record Error(string Title, string Type, int Status = 400)
    {
        public static readonly Error NotFound = new("NotFound", "NotFound", 404);

        public static readonly Error Unknown = new("Unknown", "Internal", 500);
    }
}