using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base.Converters
{
    [Serialization.CustomConverter]
    public class PriceTagConverter : JsonConverter<PriceTag>
    {
        public override PriceTag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(JsonSerializer.Deserialize<int>(ref reader, options));

        public override void Write(Utf8JsonWriter writer, PriceTag value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value.NumericalValue, options);
    }
}
