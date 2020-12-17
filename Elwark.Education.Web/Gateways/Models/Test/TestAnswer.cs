using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    [JsonConverter(typeof(TestAnswerJsonConverter))]
    public abstract record TestAnswer;

    public sealed record TextAnswer(string Text) : TestAnswer;

    public sealed record SingleAnswer(int Number) : TestAnswer;

    public sealed record ManyAnswer(IEnumerable<int> Numbers) : TestAnswer;

    internal class TestAnswerJsonConverter : JsonConverter<TestAnswer?>
    {
        public override void WriteJson(JsonWriter writer, TestAnswer? value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);

        public override TestAnswer? ReadJson(JsonReader reader, Type objectType, TestAnswer? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            if (jObject.Type == JTokenType.Null)
                return null;

            foreach (var prop in jObject.Properties())
                switch (prop.Value.Type)
                {
                    case JTokenType.Array when nameof(ManyAnswer.Numbers)
                        .Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase):
                        return new ManyAnswer(prop.Value.Values<int>());

                    case JTokenType.Integer when nameof(SingleAnswer.Number)
                        .Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase):
                        return new SingleAnswer(prop.Value.Value<int>());

                    case JTokenType.String when nameof(TextAnswer.Text)
                        .Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase):
                        return new TextAnswer(prop.Value.Value<string>());
                }

            return null;
        }
    }
}