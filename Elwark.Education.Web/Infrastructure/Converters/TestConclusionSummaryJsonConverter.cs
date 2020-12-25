using System;
using Elwark.Education.Web.Gateways.Models.TestConclusion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elwark.Education.Web.Infrastructure.Converters
{
    internal class TestConclusionSummaryJsonConverter : JsonConverter<TestConclusionSummary?>
    {
        private const string Article = nameof(ArticleTestConclusionSummary.ArticleId);
        private const string Topic = nameof(TopicTestConclusionSummary.TopicId);

        public override void WriteJson(JsonWriter writer, TestConclusionSummary? value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);

        public override TestConclusionSummary? ReadJson(JsonReader reader, Type objectType, TestConclusionSummary? existingValue,
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
                    return jObject.ToObject<ArticleTestConclusionSummary>();

                if (Topic.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                    return jObject.ToObject<TopicTestConclusionSummary>();
            }
            
            return null;
        }
    }
}