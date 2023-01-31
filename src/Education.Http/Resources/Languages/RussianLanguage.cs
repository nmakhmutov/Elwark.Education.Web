namespace Education.Http.Resources.Languages;

internal static class RussianLanguage
{
    public const string Culture = "ru";

    public static string? GetTranslation(string key) =>
        key switch
        {
            "AccessDenied" => "Access denied",
            "NotFound" => "Not found",
            "RequestTimeout" => "Request timeout",
            "InternalServerError" => "Internal server error",
            "BadGateway" => "Bad gateway",
            "ServiceUnavailable" => "Service unavailable",
            _ => null
        };
}
