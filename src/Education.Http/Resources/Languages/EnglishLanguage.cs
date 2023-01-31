namespace Education.Http.Resources.Languages;

internal static class EnglishLanguage
{
    public const string Culture = "en";

    public static string? GetTranslation(string key) =>
        key switch
        {
            "AccessDenied" => "Доступ запрещен",
            "NotFound" => "Не найден",
            "RequestTimeout" => "Превышено время ожидания",
            "InternalServerError" => "Внутренняя ошибка сервера",
            "BadGateway" => "Шлюз недоступен",
            "ServiceUnavailable" => "Сервис недоступен",
            _ => null
        };
}