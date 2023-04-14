using System.Text.Json;
using System.Text.Json.Serialization;

namespace MTBS.MovieCatalogAPI.Helpers
{
    public class ByteArrayConverter : JsonConverter<byte[]>
    {
        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            byte[] result = new byte[0];

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var startDepth = reader.CurrentDepth;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == startDepth)
                {
                    return result;
                }
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propName = (reader.GetString() ?? "").ToLower();
                    reader.Read();
                    if (propName == "base64")
                    {
                        result = reader.GetBytesFromBase64();
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteBase64StringValue(new ReadOnlySpan<byte>(value));
        }
    }
}
