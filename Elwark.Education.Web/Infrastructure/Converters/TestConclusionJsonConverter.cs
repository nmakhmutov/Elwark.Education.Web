using System;
using Elwark.Education.Web.Services.History.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elwark.Education.Web.Infrastructure.Converters
{
    internal class TestConclusionJsonConverter : JsonConverter<TestConclusion?>
    {
        private const string Article = nameof(ArticleTestConclusion.ArticleId);
        private const string Topic = nameof(TopicTestConclusion.TopicId);

        public override void WriteJson(JsonWriter writer, TestConclusion? value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);

        public override TestConclusion? ReadJson(JsonReader reader, Type objectType, TestConclusion? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            if (jObject.Type == JTokenType.Null)
                return null;

            foreach (var property in jObject.Properties())
            {
                if (Article.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                    return jObject.ToObject<ArticleTestConclusion>();

                if (Topic.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                    return jObject.ToObject<TopicTestConclusion>();
            }
            
            return null;
        }
    }
}