using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Features.History.Clients.Article.Model;

namespace Education.Web.Client.Features.History.Clients.JsonConverters;

internal sealed class ArticleDetailConverter : JsonConverter<ArticleDetail?>
{
    public override ArticleDetail? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "battle" => document.Deserialize<ArticleDetail.BattleModel>(options),
            "empire" => document.Deserialize<ArticleDetail.EmpireModel>(options),
            "general" => document.Deserialize<ArticleDetail.GeneralModel>(options),
            "person" => document.Deserialize<ArticleDetail.PersonModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown article detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, ArticleDetail? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
