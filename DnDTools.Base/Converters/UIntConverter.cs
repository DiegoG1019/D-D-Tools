using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DiegoG.Utilities;
using DiegoG.Utilities.IO;

namespace DiegoG.DnDTools.Base.Converters
{
    //[Serialization.CustomConverter] This causes an infinite recursion which ends in a stack overflow. I have no idea why.
    public class UIntConverter : JsonConverter<uint>
    {
        public override uint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => Convert.ToUInt32(JsonSerializer.Deserialize(ref reader, typeof(uint), options) as string, 16);

        public override void Write(Utf8JsonWriter writer, uint value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, Convert.ToString(value, 16), options);
    }
}
