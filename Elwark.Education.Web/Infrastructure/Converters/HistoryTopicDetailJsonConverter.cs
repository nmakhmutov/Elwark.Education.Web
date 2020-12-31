using System;
using Elwark.Education.Web.Gateways.Models.History;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elwark.Education.Web.Infrastructure.Converters
{
    internal class HistoryTopicDetailJsonConverter : JsonConverter<HistoryTopicDetail?>
    {
        private const string Tags = nameof(HistoryPersonTopicDetail.Characteristics);

        public override void WriteJson(JsonWriter writer, HistoryTopicDetail? value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);

        public override HistoryTopicDetail? ReadJson(JsonReader reader, Type objectType, HistoryTopicDetail? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            if (jObject.Type == JTokenType.Null)
                return null;

            if (jObject.TryGetValue(Tags, StringComparison.InvariantCultureIgnoreCase, out _))
                return jObject.ToObject<HistoryPersonTopicDetail>();
            
            return jObject.ToObject<HistoryEventTopicDetail>();
        }
    }
}