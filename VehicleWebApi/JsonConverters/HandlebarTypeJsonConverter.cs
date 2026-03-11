using System.Text.Json;
using System.Text.Json.Serialization;
using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.JsonConverters
{
    public class HandlebarTypeJsonConverter : JsonConverter<HandlebarType>
    {
        public override HandlebarType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return value?.ToLower() switch
            {
                "clip-ons" => HandlebarType.ClipOns,
                "clipons" => HandlebarType.ClipOns,

                "ape hangers" => HandlebarType.ApeHangers,
                "apehangers" => HandlebarType.ApeHangers,

                "drag bars" => HandlebarType.DragBars,
                "dragbars" => HandlebarType.DragBars,

                "motocross" => HandlebarType.Motocross,

                "riser" => HandlebarType.Riser,

                _ => throw new JsonException($"Invalid handlebar type: {value}")
            };
        }

        public override void Write(Utf8JsonWriter writer, HandlebarType value, JsonSerializerOptions options)
        {
            var result = value switch
            {
                HandlebarType.ClipOns => "Clip-Ons",
                HandlebarType.ApeHangers => "Ape Hangers",
                HandlebarType.DragBars => "Drag Bars",
                HandlebarType.Motocross => "Motocross",
                HandlebarType.Riser => "Riser",
                _ => throw new ArgumentOutOfRangeException()
            };

            writer.WriteStringValue(result);
        }
    }
}
