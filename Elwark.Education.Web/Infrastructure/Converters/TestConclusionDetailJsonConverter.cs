using System;
using Elwark.Education.Web.Gateways.Models.TestConclusion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elwark.Education.Web.Infrastructure.Converters
{
    internal class TestConclusionDetailJsonConverter : JsonConverter<TestConclusionDetail?>
    {
        private const string Article = nameof(ArticleTestConclusionDetail.ArticleId);
        private const string Topic = nameof(TopicTestConclusionDetail.TopicId);

        public override void WriteJson(JsonWriter writer, TestConclusionDetail? value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);

        public override TestConclusionDetail? ReadJson(JsonReader reader, Type objectType, TestConclusionDetail? existingValue,
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
                    return jObject.ToObject<ArticleTestConclusionDetail>();

                if (Topic.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                    return jObject.ToObject<TopicTestConclusionDetail>();
            }
            
            return null;
        }
    }
}