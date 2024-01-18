using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotnetGenerator.ZConfig
{
    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.String 
                ? Convert.ToDecimal(reader.GetString(), System.Globalization.CultureInfo.GetCultureInfo("es-ES")) 
                : reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value);
    }
}
